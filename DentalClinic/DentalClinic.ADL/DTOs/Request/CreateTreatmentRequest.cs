using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreateTreatmentRequest
    {
        [Required]
        [Range(.01,double.MaxValue,ErrorMessage = "Treatment Price out range")]
        public decimal TreatmentPrice { get; set; }
        [Required]
        public List<CreateTreatmentTranslationRequest>? createTreatmentTranslation { get; set; }
    }
}
