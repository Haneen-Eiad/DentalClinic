using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class Equipment : BaseModel
    {
        [MaxLength(100, ErrorMessage = "Too long text")]
        public string EquipmentName { get; set; }

        public string EquipmentCategoriesId { get; set; }
        public EquipmentCategories equipmentCategories { get; set; }
        public int Quantity { get; set; }

    }
}
