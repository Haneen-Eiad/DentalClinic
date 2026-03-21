using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class Expense :BaseModel
    {
        [MaxLength(100,ErrorMessage ="Too long text")]
        public string ExpenseName { get; set; }
        public decimal BillPrice { get; set; }
        public bool IsPayed { get; set; }
        [MaxLength(100,ErrorMessage ="Too long text")]
        public string CompanyName { get; set; }
        public DateTime BillDate { get; set; }

    }
}
