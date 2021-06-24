using edureka_sampleapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edureka_sampleapp.Components
{
    public class NavigationMenuViewComponent :ViewComponent
    {
        private readonly IStoreRepository _repository;

        public NavigationMenuViewComponent(IStoreRepository repository)
        {
            _repository = repository;
        }
        public IViewComponentResult Invoke()
        {
           // ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_repository.Accounts
            .Select(x => x.TypeOfAccount)
            .Distinct()
            .OrderBy(x => x).ToList());
        }
    }
}
