using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public enum PaymentMethodEnum
    {
        Visa = 0,
        Cash = 1,
        Check = 2
    }
    public enum PaymentStatusEnum
    {
        UnPaid = 0,
        Paid= 1,
        Refunded =2

    }
    public class Payment :  BaseModel
    {
        public PaymentMethodEnum PaymentMethod { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }
        public DateTime PaymentDate     { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string? TransactionReference { get; set; }

        //relation with appointment
        public string? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }

        //realtion with supplier 
        public string? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
