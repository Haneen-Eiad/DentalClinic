using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request.Create
{
    public class CreateSupplierRequest
    {
        [MaxLength(20,ErrorMessage = "Supplier Identification Card number too long ")]
        [Required]
        public string SupplierIdentificationCard { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "Company name too long")]
        [Required]
        public string CompanyName { get; set; } = string.Empty;
        [MaxLength(100, ErrorMessage = "Seller name too long")]
        public string? sellerName { get; set; }
        [MaxLength(500, ErrorMessage = "Description too long")]
        public string? SupplierDescription { get; set; }
        [Range(0,double.MaxValue,ErrorMessage ="Debt value is invalid")]
        public decimal? Debt { get; set; }
     


    }
}
