using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.Models
{
    // Holds Account information
    public class Account
    {
        public int CustomerId { get; set; }
        [Key]
        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public double Balance { get; set; }
        public string TypeOfAccount { get; set; }     

    }
   
}
