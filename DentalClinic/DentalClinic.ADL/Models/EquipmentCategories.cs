using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class EquipmentCategories : BaseModel
    {
        public string CategoryName { get; set; }
        public List <Equipment> Equipment { get; set; }
    }
}
