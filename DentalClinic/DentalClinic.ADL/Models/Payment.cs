using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public PaymentStatusEnum PaymentStatus { get; set; } = PaymentStatusEnum.UnPaid;
        public DateTime? PaymentDate { get; set; } = DateTime.UtcNow;
        [Range(0,double.MaxValue)]
        public decimal PaymentAmount { get; set; }
        [MaxLength(100)]
        public string? TransactionReference { get; set; }

        //relation with appointment
        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }

        //realtion with supplier 
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
