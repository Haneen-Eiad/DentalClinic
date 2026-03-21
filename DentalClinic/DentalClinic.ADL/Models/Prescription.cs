using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class Prescription : BaseModel
    {
        [MaxLength(500,ErrorMessage ="Too long text")]
        public string PrescriptionNote { get; set; }

        //relation with Appointment
        public string AppointmentId { get; set; }
        public Appointment Appointment { get; set; }


        //relation with Patient
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
        public List<PrescriptionItem> prescriptionItems { get; set; }
 
    }
}
