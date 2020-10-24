using System;
using System.Collections.Generic;
using System.Linq;
using IDENTITY;
using BUSINESS;
using MODELS;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data;

namespace TATA_BANK.Controllers
{
    public class BankManagerController : Controller
    {
        private IMANAGER_BUSINESS manager_business = new MANAGER_BUSINESS();
        // GET: BankManager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BankManager()
        {
            return View();
        }
        [HttpGet]
        public ActionResult VIEWMANAGER()
        {
            manager_business.VIEWMANAGER();
            return View();
        }
       
    }
}