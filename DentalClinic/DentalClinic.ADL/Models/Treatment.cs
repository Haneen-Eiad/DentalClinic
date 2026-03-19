using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class Treatment : BaseModel
    {
        public List<TreatmentTranslation> treatmentTranslations {  get; set; }
        public decimal TreatmentPrice { get; set; }
    }
}
