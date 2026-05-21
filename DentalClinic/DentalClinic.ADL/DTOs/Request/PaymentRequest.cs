using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class PaymentRequest
    {
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required]
        public PaymentMethodEnum PaymentMethod { get; set; }
        [Required]
        [Range(.01,double.MaxValue,ErrorMessage = "Payment amount must be greater than 0")]
        public decimal PaymentAmount { get; set; }
        [MaxLength(100,ErrorMessage = "Transaction Reference too long")]
        public string? TransactionReference { get; set; }
    }
}
