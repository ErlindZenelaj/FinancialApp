using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialApp.Controllers
{
    public class RoleController : Controller
    {

        [Authorize (Policy = "EmployeeOnly")]

        public IActionResult Index()
        {
            return View();
        }
    }
}

