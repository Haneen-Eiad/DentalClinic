using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class PrescriptionItem : BaseModel
    {
        //relation with Prescription
        public string PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }

        //relation with Medicine
        public string MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
    }
}
