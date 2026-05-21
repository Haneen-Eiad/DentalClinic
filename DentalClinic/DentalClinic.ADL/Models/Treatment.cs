using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class Treatment : BaseModel
    {
        //الاجراء للمريض
        [Required]
        public List<TreatmentTranslation>? treatmentTranslations {  get; set; }
        [Required]
        [Range(.01,double.MaxValue)]
        public decimal TreatmentPrice { get; set; }
    }
}
