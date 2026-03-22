using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class TreatmentTranslation
    {
        public int Id { get; set; }
        [MaxLength(100,ErrorMessage ="Too long text")]
        public string? TreatmentName { get; set; }
        [MaxLength(500,ErrorMessage ="Too long text")]
        public string? TreatmentDescription { get; set; }
        public string? Language { get; set; } = "en";

        public int? TreatmentId { get; set; }
        public Treatment? Treatment { get; set; }
    }
}
