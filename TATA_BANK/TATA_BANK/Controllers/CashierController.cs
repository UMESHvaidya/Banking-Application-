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
    public class CashierController : Controller
    {
        private ICASHIER_BUSINESS cashierbusiness = new CASHIER_BUSINESS();
        private ITRANSFERBUSINESS TRANSFER = new TRANSFER_BUSINESS();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Cashier()
        {
            return View();
        }

        /// <summary>
        /// Method to Insert The Customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult INSERT_CUSTOMER()
        {
            return View();
        }
        [HttpPost]
        public ActionResult INSERT_CUSTOMER(CUSTOMER cust)
        {
            cashierbusiness.INSERT_CUSTOMER(cust);
            return View();
        }

        /// <summary>
        /// Method to transfer the Money
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Fund_Transfer()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Fund_Transfer(Fund_Transfer OBJ)
        {
            TRANSFER.FUNDTRANSFER(OBJ);
            return View();
        }

        /// <summary>
        /// Method which will manage the Account
        /// Deposit,Withdraw,Transfer amount
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public ActionResult MANAGE_ACCOUNT()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MANAGE_ACCOUNT(CUSTOMER OBJ)
        {
            string url = string.Format("/Cashier/info_user?accno={0}", OBJ.ACC_NO);         
            return Redirect(url);
           
        }
        [HttpGet]
        public ActionResult info_user()
        {
            List<CUSTOMER> list = new List<CUSTOMER>();
            CUSTOMER OBJ = new CUSTOMER();
            DataSet dt = new DataSet();
            OBJ.ACC_NO = int.Parse(Request.QueryString["accno"]);
            Int64 accno = Convert.ToInt64(OBJ.ACC_NO);
            list = cashierbusiness.info_user(accno);
            return View(list);
        }


        /// <summary>
        /// Method to depost the amount  
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Deposit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Deposit(CUSTOMER OBJ)
        {
            cashierbusiness.Deposit(OBJ);
            return View();
        }
        /// <summary>
        /// Method to withdraw The Money
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult Withdraw()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Withdraw(CUSTOMER OBJ)
        {
            cashierbusiness.Withdraw(OBJ);
            return View();
        }
    }
}


