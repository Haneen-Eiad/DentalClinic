using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class EquipmentCategories : BaseModel
    {
        [MaxLength(100, ErrorMessage = "Too long text")]
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        public List <Equipment>? Equipment { get; set; }
    }
}
