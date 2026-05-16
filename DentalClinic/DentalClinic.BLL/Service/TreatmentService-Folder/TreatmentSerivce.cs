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

namespace DentalClinic.BLL.Service.TreatmentService_Folder
{
    public class TreatmentSerivce : ITreatmentService
    {
        private readonly IGenericRepository<TreatmentTranslation> _treatmentTranslation;
        private readonly IGenericRepository<Treatment> _treatment;

        public TreatmentSerivce(IGenericRepository<TreatmentTranslation> TreatmentTranslation,
            IGenericRepository<Treatment> Treatment
            )
        {
            _treatmentTranslation = TreatmentTranslation;
            _treatment = Treatment;
        }

        public async Task<CreateTreatmentResponse> CreateTreatmentAsync(CreateTreatmentRequest ceateTreatmentRequest)
        {

            //see if there is a translted data or not
            if(ceateTreatmentRequest.createTreatmentTranslationRequests == null 
                || !ceateTreatmentRequest.createTreatmentTranslationRequests.Any())
            {

                return new CreateTreatmentResponse
                {
                    Success = false,
                    Message = "at least ont translation is required"
                };
            }
            // see if the languse dublicated
            var DublicatedLang = ceateTreatmentRequest.createTreatmentTranslationRequests
                .GroupBy(l => l.Language)
                .Any(l => l.Count() > 1);

            if (DublicatedLang) {
                return new CreateTreatmentResponse
                {
                    Success = false,
                    Message = " you cant Dublicate Language"
                };
            }
            //use manual mapping 
            var treatmentData = new Treatment
            {
                TreatmentPrice = ceateTreatmentRequest.TreatmentPrice
            };

           
            var Treatment = await _treatment.CreateAsync(treatmentData);

            

            if (Treatment is null)
            {
                return new CreateTreatmentResponse
                {
                    Success = false,
                    Message = " can't create treatment pleas check your inputs"
                };


            }
            if(ceateTreatmentRequest.createTreatmentTranslationRequests != null)
            {
                foreach(var Tr in ceateTreatmentRequest.createTreatmentTranslationRequests)
                {
                    var TreatmentTranslation = new TreatmentTranslation
                    {
                        TreatmentId = Treatment.Id,
                        TreatmentName = Tr.TreatmentName,
                        TreatmentDescription = Tr.TreatmentDescription,
                        Language = Tr.Language

                    };
                    await _treatmentTranslation.CreateAsync(TreatmentTranslation);
                }
            }

           
            return new CreateTreatmentResponse
            {
                Success = true,
                Message = "Treatment created successfully"
            };
        }
    }
}
