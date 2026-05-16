using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreateTreatmentTranslationRequest
    {
        public string? TreatmentName { get; set; }
        public string? TreatmentDescription { get; set; }
        public string? Language { get; set; } = "en";
    }
}
