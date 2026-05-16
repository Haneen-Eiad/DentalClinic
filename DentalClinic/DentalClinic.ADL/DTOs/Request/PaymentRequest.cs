using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class PaymentRequest
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PaymentMethodEnum? PaymentMethod { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PaymentStatusEnum? PaymentStatus { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string? TransactionReference { get; set; }
    }
}
