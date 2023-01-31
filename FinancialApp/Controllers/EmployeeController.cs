using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new salary());
        }


        [HttpPost]
        public ActionResult Index(salary s)
        {
            if (s.sal > 50000)

            {
                s.tax = s.sal * 10 / 100;
            }

            else if (s.sal > 30000)

            {
                s.tax = s.sal * 5 / 100;
            }

            else

            {
                s.tax = 0;
            }
             
            s.nsal = s.sal - s.tax;

            return View(s);

        }
    }
}

