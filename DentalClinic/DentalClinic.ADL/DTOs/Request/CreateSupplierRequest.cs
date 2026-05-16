using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreateSupplierRequest
    {
        public string SupplierIdentificationCard { get; set; }
        public string? CompanyName { get; set; }
        public string? sellerName { get; set; }
        public string? SupplierDescription { get; set; }
        public decimal? Dept { get; set; }
        //public List<Payment>? payments { get; set; }

    }
}
