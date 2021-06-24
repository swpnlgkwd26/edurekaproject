using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.Models
{
    public interface IStoreRepository
    {
        IEnumerable<Account> Accounts { get; }
        void AddAccount(Account account);
        bool DeleteAccount(int accountNumber);
        bool UpdateAccount(Account account);
        IEnumerable<Account> GetAccount(string accountType);
        Account GetAccountByNumber(int accountNumber);
    }
}
