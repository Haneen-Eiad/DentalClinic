using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class Medicine : BaseModel
    {
        public string MedicineName { get; set; }
        public decimal MedicinePrice { get; set; }

        //relation with SupplierMedicines
        public string SupplierId { get; set; } 
        public Supplier Supplier { get; set; }

        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }


    }
}
