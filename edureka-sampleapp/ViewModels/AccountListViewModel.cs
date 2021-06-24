using edureka_sampleapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.ViewModels
{
    public class AccountListViewModel
    {
        public IEnumerable<Account> Accounts { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
