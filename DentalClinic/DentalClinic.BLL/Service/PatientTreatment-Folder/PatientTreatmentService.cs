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

namespace DentalClinic.BLL.Service.PatientTreatment_Folder
{
    public class PatientTreatmentService : IPatientTreatmentService
    {
        private readonly IGenericRepository<PatientTreatment> _patientTreatmentRepo;

        public PatientTreatmentService(IGenericRepository<PatientTreatment> PatientTreatmentRepo)
        {
            _patientTreatmentRepo = PatientTreatmentRepo;
        }

        public async Task<CreatePatientTreatmentResponse> CreatePatientTreatmentAsync(CreatePatientTreatmentRequest patientTreatmentRequest)
        {
            var PatientTreatmentData = patientTreatmentRequest.Adapt<PatientTreatment>();
            var patientTreatment = await _patientTreatmentRepo.CreateAsync(PatientTreatmentData);

            if(patientTreatment is null)
            {
                return new CreatePatientTreatmentResponse
                {
                    Success = false,
                    Message = " can't create Patient Treatment "
                };
            }
            return new CreatePatientTreatmentResponse
            {
                Success = true,
                Message = " Patient Treatment created successfuly"
            };
        }
    }
}
