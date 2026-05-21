using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class PrescriptionItem : BaseModel
    {
        //relation with Prescription
        [Required]
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        //relation with Medicine
        public int? MedicineId { get; set; }
        public Medicine? Medicine { get; set; }
        [MaxLength(10)]
        public string? Dosage { get; set; }
        [MaxLength(10)]
        public string? Frequency { get; set; }
        public string? Duration { get; set; }
    }
}
