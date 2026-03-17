using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class Expense :BaseModel
    {
        public string ExpenseName { get; set; }
        public decimal BillPrice { get; set; }
        public bool IsPayed { get; set; }
        public string CompanyName { get; set; }
        public DateTime BillDate { get; set; }

    }
}
