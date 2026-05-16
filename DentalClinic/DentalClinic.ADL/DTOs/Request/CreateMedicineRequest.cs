using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreateMedicineRequest
    {
        public string? MedicineName { get; set; }
        public decimal? MedicinePrice { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? Description { get; set; }
        public int? StockQuantity { get; set; }
    }
}
