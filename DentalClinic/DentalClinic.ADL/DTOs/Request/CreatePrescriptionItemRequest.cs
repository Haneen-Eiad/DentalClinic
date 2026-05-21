using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreatePrescriptionItemRequest
    {
     
      
   
        public int? MedicineId { get; set; }
        [MaxLength(10,ErrorMessage ="Dosage must be less than 10")]
        public string? Dosage { get; set; }
        [MaxLength(10, ErrorMessage = "Frequency must be less than 10")]
        public string? Frequency { get; set; }
        public string? Duration { get; set; }
    }
}
