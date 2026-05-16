using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreateTreatmentRequest
    {
        public decimal? TreatmentPrice { get; set; }
        public List<CreateTreatmentTranslationRequest>? createTreatmentTranslationRequests { get; set; }
    }
}
