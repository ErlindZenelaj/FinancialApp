using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FinancialApp.Core;
using Microsoft.AspNetCore.Identity;

namespace FinancialApp.Controllers
{


    public class RoleController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = Constants.Policies.RequireManager)]

        public IActionResult Manager()
        {
            return View();
         }


        [Authorize(Roles = $"{Constants.Roles.Administrator},{Constants.Roles.Manager}")]

        public IActionResult Admin()
        {
            return View();
        }


        
    }
}

