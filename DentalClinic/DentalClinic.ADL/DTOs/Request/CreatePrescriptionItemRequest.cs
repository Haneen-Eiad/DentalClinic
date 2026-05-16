using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreatePrescriptionItemRequest
    {
        //relation with Prescription
        public int? PrescriptionId { get; set; }
        //relation with Medicine
        public int? MedicineId { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public string? Duration { get; set; }
    }
}
