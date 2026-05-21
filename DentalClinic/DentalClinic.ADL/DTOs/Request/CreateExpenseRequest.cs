using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreateExpenseRequest 
    {
        [Required]
        [MaxLength(100,ErrorMessage ="Too long Text")]
        public string ExpenseName { get; set; } = string.Empty;
        [Required]
        [Range(.01, double.MaxValue, ErrorMessage = "out of the range")]
        public decimal BillPrice { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage = "Company Name is too long")]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        public DateTime BillDate { get; set; }
    }
}
