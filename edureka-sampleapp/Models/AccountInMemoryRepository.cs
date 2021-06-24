using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.Models
{
    public class AccountInMemoryRepository : IStoreRepository
    {
        static List<Account> accounts = new List<Account>
        {
            new Account
            {
                CustomerId = 1,
                AccountNumber=10000,
                AccountHolderName="Sachin Tendulkar",
                Address="Mumbai",
                MobileNumber="43243252",
                Balance=100000,
                TypeOfAccount="Saving"
            },
            new Account
            {
                CustomerId = 1,
                AccountNumber=10001,
                AccountHolderName="Sachin Tendulkar",
                Address="Mumbai",
                MobileNumber="43243252",
                Balance=20000,
                TypeOfAccount="Current"
            },

            new Account
            {
                CustomerId = 2,
                AccountNumber=10002,
                AccountHolderName="Saurav Ganguly",
                Address="Kolkata",
                MobileNumber="43243252",
                Balance=100000,
                TypeOfAccount="Saving"
            },
            new Account
            {
                CustomerId = 2,
                AccountNumber=10003,
                AccountHolderName="Saurav Ganguly",
                Address="Mumbai",
                MobileNumber="43243252",
                Balance=20000,
                TypeOfAccount="Current"
            },

            new Account
            {
                CustomerId = 3,
                AccountNumber=10004,
                AccountHolderName="Rahul Dravid",
                Address="Benglore",
                MobileNumber="43243252",
                Balance=100000,
                TypeOfAccount="Saving"
            },
            new Account
            {
                CustomerId = 3,
                AccountNumber=10005,
                AccountHolderName="Rahul Dravid",
                Address="Benglore",
                MobileNumber="43243252",
                Balance=20000,
                TypeOfAccount="Current"
            }

        };
        public IEnumerable<Account> Accounts => accounts;
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }
        public bool DeleteAccount(int accountNumber)
        {
            var account = accounts.Single(x =>
            x.AccountNumber == accountNumber);
            accounts.Remove(account);
            return true;
        }
        public IEnumerable<Account> GetAccount(string accountType)
        {
            var accountsInfo = accounts
                .Where(x => x.TypeOfAccount == accountType);
            return accountsInfo;
        }
        public Account GetAccountByNumber(int accountNumber)
        {
            var accountsInfo = accounts
              .Single(x => x.AccountNumber == accountNumber);
            return accountsInfo;
        }
        public bool UpdateAccount(Account account)
        {
            var searchedAccount = accounts.Single(x => x.AccountNumber == account.AccountNumber);
            searchedAccount.AccountHolderName = account.AccountHolderName;
            searchedAccount.Balance = account.Balance;
            searchedAccount.Address = account.Address;
            return true; ;
        }
    }
}
