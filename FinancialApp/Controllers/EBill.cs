using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinancialApp.Models;
using FinancialApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using static FinancialApp.Core.Constants;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialApp.Controllers
{
    public class EBill : Controller
    {
        // GET: /<controller>/
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            Data data = new Data();
            var list = data.GetAllDetail();
            return View(list);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult Create(BillDetail details)
        {
            Data data = new Data();
            data.SaveBillDetails(details);
            ModelState.Clear();
           
            return View();
        }

        public IActionResult CreateItem(Items item)
        {
            return PartialView("_CreateItem", item);
        }


        [Authorize(Roles = "Administrator")]
        public ActionResult ViewBill(int Id)
        {
            Data data = new Data();
            var details =  data.GetDetail(Id);
            return View(details);
        }
    }
}

