using edureka_sampleapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.Models
{
    public class AccountDBRepository : IStoreRepository
    {
        private readonly EdurekaDBContext _context;

        public AccountDBRepository(EdurekaDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Account> Accounts => _context.Accounts;

        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account); // Add
            _context.SaveChanges();// Commit
        }

        public bool DeleteAccount(int accountNumber)
        {
            var account = _context.Accounts.Single(p => p.AccountNumber == accountNumber);// Find
            _context.Accounts.Remove(account);// Delete
            _context.SaveChanges();// Commit
            return true;
        }

        public string FundTransfer(FundTransferViewModel fundTransfer)
        {
            string message = "";
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var toAccountInfo = _context.Accounts.Single(p => p.AccountNumber == fundTransfer.ToAccount);
                    var fromAccountInfo = _context.Accounts.Single(p => p.AccountNumber == fundTransfer.FromAccount);
                    if (toAccountInfo == null || fromAccountInfo == null)
                    {
                        return "Account Information is not correct";
                    }
                    if (toAccountInfo.AccountNumber == fromAccountInfo.AccountNumber)
                    {
                        return "To & From Account Number cant be same";
                    }
                    if (fromAccountInfo.Balance - fundTransfer.Amount < 0)
                    {
                        return "Transaction Failed Due to Insufficient Balance";
                    }
                    else
                    {
                        fromAccountInfo.Balance = fromAccountInfo.Balance - fundTransfer.Amount;
                        toAccountInfo.Balance = toAccountInfo.Balance + fundTransfer.Amount;
                        _context.SaveChanges();
                        transaction.Commit();
                        message = "Transaction Completed Successfully";
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    message = "Transaction Failed";
                }

                return message;
            }
        }

        public IEnumerable<Account> GetAccount(string accountType)
        {
            var accounts = _context.Accounts.Where(x => x.TypeOfAccount == accountType);
            return accounts;
        }

        public Account GetAccountByNumber(int accountNumber)
        {
            return _context.Accounts.Single(p => p.AccountNumber == accountNumber);
        }

        public bool UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return true;
        }
    }
}
