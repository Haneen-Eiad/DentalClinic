using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreateTreatmentTranslationRequest
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Too long Treatment Name")]
        public string TreatmentName { get; set; } =string.Empty;
        [MaxLength(500, ErrorMessage = "Too long Treatment Description")]
        public string? TreatmentDescription { get; set; }
        [Required]
        [MaxLength(5)]
        public string Language { get; set; } = "en";
    }
}
