using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace GraphQLServer.Models
{
    public class CustomerPaymentInfo
    {
        [Key]
        [DataMember]
        public int PaymentInfoId { get; set; }
        public string PaymentType { get; set; } // Example: "Card", "Bank", "UPI"
        public string? CardNumber { get; set; } // Null if PaymentType is "Bank"
        public string? BankName { get; set; } // Null if PaymentType is "Card"
        public string? AccountNumber { get; set; } // Null if PaymentType is "Card"
        public string? UpiId { get; set; } // Null if PaymentType is "Card" or "BANK"
        public bool IsPrimary { get; set; } // Marks the primary payment method

        // Foreign key
        public int CustomerId { get; set; }
        //[NotMapped]
        //public Customer Customer { get; set; }
    }
}
