using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class Equipment : BaseModel
    {
        public string Name { get; set; }

        public string EquipmentCategoriesId { get; set; }
        public EquipmentCategories equipmentCategories { get; set; }
        public int Quantity { get; set; }

    }
}
