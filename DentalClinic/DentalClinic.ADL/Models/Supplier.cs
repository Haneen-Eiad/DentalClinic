using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class Supplier : BaseModel
    {
        public string? CompanyName { get; set; }
        public string? sellerName { get; set; }
        public string? SupplierDescription { get; set; }

        //relation between user  to use phone number and email 
        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        //relation with payment to get the payment type for the supplier 
        public List<Payment>? payments { get; set; }

        public decimal Dept { get; set; } // i should put dept as bool also ? and quntity ?

        //realtion with Medicines
        public List <Medicine> medicines { get; set; }


    }
}
