using edureka_sampleapp.Models;
using edureka_sampleapp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IStoreRepository _repository;
        public int PageSize = 3;
        public CustomerController(IStoreRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index(string category, int accountPage = 1)
        {
            var accountListViewModel = new AccountListViewModel
            {
                Accounts = _repository.Accounts
                            .Where(p => category == null || p.TypeOfAccount == category)
                            .OrderBy(p => p.CustomerId)
                            .Skip((accountPage - 1) * PageSize)
                            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = accountPage,
                    ItemsPerPage = PageSize,                  
                    TotalItems = category == null ?
                        _repository.Accounts.Count() :
                        _repository.Accounts.Where(e =>
                        e.TypeOfAccount == category).Count()
                },
                CurrentCategory = category
            };
            return View(accountListViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AccountEditModel accountEditModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account
                {
                    AccountHolderName = accountEditModel.AccountHolderName,
                    AccountNumber = accountEditModel.AccountNumber,
                    Address = accountEditModel.Address,
                    Balance = accountEditModel.Balance,
                    CustomerId = accountEditModel.CustomerId,
                    MobileNumber = accountEditModel.MobileNumber,
                    TypeOfAccount = accountEditModel.TypeOfAccount
                };
                _repository.AddAccount(account);
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }

        public IActionResult Delete(int accountno)
        {
            _repository.DeleteAccount(accountno);
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Update(int accountno)
        {
            var account = _repository.GetAccountByNumber(accountno);
            AccountEditModel accountEditModel = new AccountEditModel
            {
                AccountHolderName = account.AccountHolderName,
                AccountNumber = account.AccountNumber,
                Address = account.Address,
                Balance = account.Balance,
                CustomerId = account.CustomerId,
                MobileNumber = account.MobileNumber,
                TypeOfAccount = account.TypeOfAccount
            };
            return View(accountEditModel);
        }

        [HttpPost]
        public IActionResult Update(AccountEditModel accountEditModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account
                {
                    AccountHolderName = accountEditModel.AccountHolderName,
                    AccountNumber = accountEditModel.AccountNumber,
                    Address = accountEditModel.Address,
                    Balance = accountEditModel.Balance,
                    CustomerId = accountEditModel.CustomerId,
                    MobileNumber = accountEditModel.MobileNumber,
                    TypeOfAccount = accountEditModel.TypeOfAccount
                };
                _repository.UpdateAccount(account);
                return RedirectToAction("Index", "Customer");

            }
            return View();
      
        }

        public IActionResult Details(int accountno)
        {
            var account = _repository.GetAccountByNumber(accountno);
            AccountViewModel accountViewModel = new AccountViewModel
            {
                AccountHolderName = account.AccountHolderName,
                AccountNumber = account.AccountNumber,
                Address = account.Address,
                Balance = account.Balance,
                CustomerId = account.CustomerId,
                MobileNumber = account.MobileNumber,
                TypeOfAccount = account.TypeOfAccount
            };
            return View(accountViewModel);
        }

        public IActionResult CalculateLoanEmi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateLoanEmi(LoanViewModel loanModel)
        {
            double r =(double) loanModel.RateOfInterest / 100;
            var subFormula = Math.Pow((1 + r),loanModel.TotalNoOfMonths);
            var numerator = loanModel.PrincipalAmount * r * subFormula;
            var denominator = subFormula - 1;
            double emi = numerator / denominator;
            ViewBag.Emi = emi.ToString("c");
            return View();
        }

    }
}
