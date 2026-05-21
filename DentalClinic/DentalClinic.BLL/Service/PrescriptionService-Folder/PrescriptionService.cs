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


    //warrrrrrrrrrrrrrrrrrrrrrrrrrning
    //i should delete the part that force to be at leAST ONE MEdicine caude prescirption may not have medicine
    //*********************
    //*********************
    //**************



    public class PrescriptionService : IPrescriptionService
    {
        private readonly IGenericRepository<Prescription> _prescriptionRepo;
        private readonly IGenericRepository<PrescriptionItem> _prescriptionItemRepo;
        private readonly IGenericRepository<Patient> _patientRepo;
        private readonly IGenericRepository<Medicine> _medicineRepo;
        private readonly IGenericRepository<Appointment> _appointmentRepo;

        public PrescriptionService(
            IGenericRepository<Prescription> PrescriptionRepo,
            IGenericRepository<PrescriptionItem> PrescriptionItemRepo,
            IGenericRepository<Patient> PatientRepo,
            IGenericRepository<Medicine> MedicineRepo,
            IGenericRepository<Appointment> AppointmentRepo

            )
        {
            _prescriptionRepo = PrescriptionRepo;
            _prescriptionItemRepo = PrescriptionItemRepo;
            _patientRepo = PatientRepo;
            _medicineRepo = MedicineRepo;
            _appointmentRepo = AppointmentRepo;
        }

        public async Task<CreatePrescriptionResponse> CreatePrescriptionAsync(
     CreatePrescriptionRequest prescriptionRequest)
        {
            try
            {
                // 1. Check Appointment exists
                var appointmentExists = await _appointmentRepo
                    .ExistsAsync(a => a.Id == prescriptionRequest.AppointmentId);

                if (!appointmentExists)
                {
                    return new CreatePrescriptionResponse
                    {
                        Success = false,
                        Message = "Appointment not found"
                    };
                }

                // 2. Validate request items
                if (prescriptionRequest.PrescriptionItems == null ||
                    !prescriptionRequest.PrescriptionItems.Any())
                {
                    return new CreatePrescriptionResponse
                    {
                        Success = false,
                        Message = "Prescription must contain at least one medicine"
                    };
                }

                // 3. Prevent duplicate medicines
                var duplicateMedicines = prescriptionRequest.PrescriptionItems
                    .GroupBy(x => x.MedicineId)
                    .Any(g => g.Count() > 1);

                if (duplicateMedicines)
                {
                    return new CreatePrescriptionResponse
                    {
                        Success = false,
                        Message = "Duplicate medicines are not allowed"
                    };
                }

                // 4. Validate medicines using ExistsAsync ONLY
                foreach (var item in prescriptionRequest.PrescriptionItems)
                {
                    var medicineExists = await _medicineRepo
                        .ExistsAsync(m => m.Id == item.MedicineId);

                    if (!medicineExists)
                    {
                        return new CreatePrescriptionResponse
                        {
                            Success = false,
                            Message = $"Medicine with Id {item.MedicineId} not found"
                        };
                    }
                }

                // 5. Create Prescription
                var prescription = prescriptionRequest.Adapt<Prescription>();

                var createdPrescription = await _prescriptionRepo
                    .CreateAsync(prescription);

                // 6. Create Prescription Items
                foreach (var item in prescriptionRequest.PrescriptionItems)
                {
                    var prescriptionItem = new PrescriptionItem
                    {
                        PrescriptionId = createdPrescription.Id,
                        MedicineId = item.MedicineId,
                        Dosage = item.Dosage,
                        Frequency = item.Frequency,
                        Duration = item.Duration
                    };

                    await _prescriptionItemRepo.CreateAsync(prescriptionItem);
                }

                return new CreatePrescriptionResponse
                {
                    Success = true,
                    Message = "Prescription created successfully"
                };
            }
            catch (Exception ex)
            {
                return new CreatePrescriptionResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
    }