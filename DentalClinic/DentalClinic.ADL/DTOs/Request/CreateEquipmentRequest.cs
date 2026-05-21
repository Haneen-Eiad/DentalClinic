using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreateEquipmentRequest
    {
        [Required]
        [MaxLength(100,ErrorMessage ="Too long text")]
        public string EquipmentName { get; set; } = string.Empty;
        [Required]
        public int EquipmentCategoriesId { get; set; }
        [Range(0,int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
    }
}
