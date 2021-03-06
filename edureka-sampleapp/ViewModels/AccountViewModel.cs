using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.ViewModels
{
    public class AccountViewModel
    {
        public int CustomerId { get; set; }
        public int AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public double Balance { get; set; }
        public string TypeOfAccount { get; set; }
    }
}
