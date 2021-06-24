using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.Models
{
    public class LoanViewModel
    {
        [Required]
        public double PrincipalAmount { get; set; }
        [Required]
        public int TotalNoOfMonths { get; set; }
        [Required]
        public double RateOfInterest { get; set; }        
    }
}
