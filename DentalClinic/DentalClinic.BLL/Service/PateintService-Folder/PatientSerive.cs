using DentalClinic.ADL.DTOs.Request;
using DentalClinic.ADL.DTOs.Response;
using DentalClinic.ADL.Models;
using DentalClinic.ADL.Repository;
using DentalClinic.ADL.Repository.PatientRepo;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.PateintService_Folder
{
    public class PatientSerive : IPatientSerive
    {
       
      
        private readonly IGenericRepository<Patient> _patientRepository;

        public PatientSerive(IGenericRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<CreatePatientResponse> CreatePatientAsync(CreatePatientRequest patientRequest)
        {
            try
            {
                var patientData = patientRequest.Adapt<Patient>();
                var patient = await _patientRepository.CreateAsync(patientData);

                if (patient is null)
                {
                    return new CreatePatientResponse { Success = false, Message = "Can't create patient" };
                }

                await _patientRepository.SaveChangesAsync();
                return new CreatePatientResponse { Success = true, Message = "Patient created successfully" };

             
            }
            catch (Exception ex)
            {
                // change the inner nessage message 
                var innerMessage = ex.InnerException?.Message ?? ex.Message;

                if (innerMessage.Contains("duplicate key") ||
                    innerMessage.Contains("IX_Patient_PatientIdentificationCard"))
                {
                    return new CreatePatientResponse { Success = false, Message = "A patient with this identification card already exists" };
                }

                throw; 
            }
            

        }

    }
}
