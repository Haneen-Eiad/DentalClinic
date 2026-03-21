using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class Supplier : BaseModel
    {
        [MaxLength(100,ErrorMessage ="Too long text")]
        public string CompanyName { get; set; }
        [MaxLength(100,ErrorMessage ="Too long Text")]
        public string sellerName { get; set; }
        [MaxLength(500,ErrorMessage ="Too long text ")]
        public string? SupplierDescription { get; set; }

        //relation between user  to use phone number and email 
        public string? UserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        //relation with payment to get the payment type for the supplier 
        public List<Payment>? payments { get; set; }

        [Range(0,double.MaxValue,ErrorMessage ="out og the range")]
        public decimal Dept { get; set; } // i should put dept as bool also ? and quntity ?

        //realtion with Medicines
        public List <Medicine> medicines { get; set; }


    }
}
