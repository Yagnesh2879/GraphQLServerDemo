using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLServer.Models
{
    public class CustomerBussines
    {
        [Key]
        [DataMember]
        public int BussinesId { get; set; }
        public string Name { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? TaxId { get; set; }
        public string? ContactPerson { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }

        // Foreign key
        public int CustomerId { get; set; }

        //[NotMapped]
        //public Customer Customer { get; set; }
    }
}
