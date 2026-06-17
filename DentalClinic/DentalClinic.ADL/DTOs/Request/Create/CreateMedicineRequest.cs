using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request.Create
{
    public class CreateMedicineRequest
    {
        [Required]
        [MaxLength(100,ErrorMessage = "Medicine Name too ,long")]
        public string MedicineName { get; set; } = string.Empty;
        [Required]
        [Range(.01,double.MaxValue,ErrorMessage ="price value must be over 0")]
        public decimal MedicinePrice { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [MaxLength(300,ErrorMessage ="Medicine Description too long")]
        public string? Description { get; set; }
        [Range(0,int.MaxValue,ErrorMessage ="Medicine stock quantity must be positive value  ")]
        public int StockQuantity { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }
}
