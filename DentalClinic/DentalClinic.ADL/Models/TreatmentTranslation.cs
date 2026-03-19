using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class TreatmentTranslation
    {
        public string Id { get; set; }
        public string? TreatmentName { get; set; }
        public string? TreatmentDescription { get; set; }
        public string Language { get; set; } = "en";

        public string TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }
}
