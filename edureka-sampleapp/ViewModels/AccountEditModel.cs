using edureka_sampleapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.ViewModels
{
    public class AccountEditModel
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public string AccountHolderName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public double Balance { get; set; }
        [Required]
        public string TypeOfAccount { get; set; }
    }
}
