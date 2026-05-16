using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreateEquipmentRequest
    {
        public string? EquipmentName { get; set; }
        public int? EquipmentCategoriesId { get; set; }
        public int? Quantity { get; set; }
    }
}
