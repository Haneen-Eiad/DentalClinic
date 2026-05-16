using DentalClinic.ADL.DTOs.Request;
using DentalClinic.ADL.DTOs.Response;
using DentalClinic.ADL.Models;
using DentalClinic.ADL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 
 Create Prescription (Parent)
→ then Create PrescriptionItems (Children)
→ inside ONE service
 
 */
namespace DentalClinic.BLL.Service.PrescriptionService_Folder
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IGenericRepository<Prescription> _prescriptionRepo;
        private readonly IGenericRepository<PrescriptionItem> _prescriptionItemRepo;
        private readonly IGenericRepository<Patient> _patientRepo;
        private readonly IGenericRepository<Medicine> _medicineRepo;

        public PrescriptionService(
            IGenericRepository<Prescription> PrescriptionRepo,
            IGenericRepository<PrescriptionItem> PrescriptionItemRepo,
            IGenericRepository<Patient> PatientRepo,
            IGenericRepository<Medicine> MedicineRepo
            )
        {
            _prescriptionRepo = PrescriptionRepo;
            _prescriptionItemRepo = PrescriptionItemRepo;
            _patientRepo = PatientRepo;
            _medicineRepo = MedicineRepo;
        }

        public async Task<CreatePrescriptionResponse> CreatePrescriptionAsync(
            CreatePrescriptionRequest prescriptionRequest)
        {
            //check if the patient exist
            var PatientExists = await _patientRepo
                .ExistsAsync(p => p.Id == prescriptionRequest.PatientId);

            if (!PatientExists)
            {
                return new CreatePrescriptionResponse
                {
                    Success = false,
                    Message = "Patient not found"
                };
            }

            //prevent duplicate medecine
            if (prescriptionRequest.PrescriptionItems != null)
            {
                var duplicateMedecine = prescriptionRequest.PrescriptionItems
                    .GroupBy(m => m.MedicineId)
                    .Any(m => m.Count() > 1);

                if (duplicateMedecine)
                {
                    return new CreatePrescriptionResponse
                    {
                        Success = false,
                        Message = "Duplicate medicines are not allowed"
                    };
                }
            }

            //create Prescription
            var CreatePrescriptionAdapt =
                prescriptionRequest.Adapt<Prescription>();

            var CreatePrescriptionData =
                await _prescriptionRepo.CreateAsync(CreatePrescriptionAdapt);

            //create PrescriptionItems
            if (prescriptionRequest.PrescriptionItems != null)
            {
                foreach (var item in prescriptionRequest.PrescriptionItems)
                {
                    var medecineExists = await _medicineRepo
                        .ExistsAsync(m => m.Id == item.MedicineId);

                    if (!medecineExists)
                    {
                        return new CreatePrescriptionResponse
                        {
                            Success = false,
                            Message =
                            $"Medicine with Id {item.MedicineId} is not found"
                        };
                    }

                    // ❌ WRONG
                    // var newprescriptionItemAdapt =
                    //     prescriptionRequest.Adapt<PrescriptionItem>();


                    // ✅ TRUE SOLUTION
                    // adapt SINGLE ITEM not whole request
                    var newprescriptionItemAdapt =
                        item.Adapt<PrescriptionItem>();


                    // ✅ VERY IMPORTANT
                    // assign generated Prescription Id
                    newprescriptionItemAdapt.PrescriptionId =
                        CreatePrescriptionData.Id;


                    // ✅ create item
                    var newprescriptionItem =
                        await _prescriptionItemRepo
                        .CreateAsync(newprescriptionItemAdapt);
                }
            }

            return new CreatePrescriptionResponse
            {
                Success = true,
                Message = "Prescription created successfully"
            };
        }
    }
}