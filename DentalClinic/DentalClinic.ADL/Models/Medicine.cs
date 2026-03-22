using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class Medicine : BaseModel
    {
        [MaxLength(200,ErrorMessage ="Too long medicine name")]
        public string? MedicineName { get; set; }
        public decimal? MedicinePrice { get; set; }

        //relation with SupplierMedicines
        public int? SupplierId { get; set; } 
        public Supplier? Supplier { get; set; }

        public DateTime ExpirationDate { get; set; }
        [MaxLength(500, ErrorMessage = "Too long text")]
        public string? Description { get; set; }
        public int? StockQuantity { get; set; }


    }
}
