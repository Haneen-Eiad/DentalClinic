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
        [MaxLength(100,ErrorMessage ="Too long text")]
        public string? CategoryName { get; set; }
        public List <Equipment>? Equipment { get; set; }
    }
}
