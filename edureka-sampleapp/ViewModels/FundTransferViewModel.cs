using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.ViewModels
{
    public class FundTransferViewModel
    {
        [Required]
        public int FromAccount { get; set; }
        [Required]
        public int ToAccount { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
