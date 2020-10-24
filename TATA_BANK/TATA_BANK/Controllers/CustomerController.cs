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
    public class CustomerController : Controller
    {
        private CUSTOMER_BUSINESS TRANSFER = new CUSTOMER_BUSINESS();
        private CASHIER_BUSINESS objjj = new CASHIER_BUSINESS();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Customer()
        {
            return View();
        }


        /// <summary>
        /// method to transfer the money
        /// takes account number as parameter 
        /// </summary>
        /// <returns></returns>


        [HttpGet]
        public ActionResult FUND_TRANSFER()//int accno
        {
            //  Fund_Transfer obj = new Fund_Transfer();

            //  obj.FROM_ACCNO = accno;
            return View();//return View(obj);
        }
        [HttpPost]
        public ActionResult FUND_TRANSFER(Fund_Transfer OBJ)
        {
            TRANSFER.FUNDTRANSFER(OBJ);
            return View();
        }

        /// <summary>
        /// This method is to see the ministatement
        /// </summary>
        /// <returns>list of statements</returns>



        [HttpGet]
        public ActionResult MINISTATEMENT()
        {
            List<Fund_Transfer> dt = new List<Fund_Transfer>();
            dt = TRANSFER.ViewDataBase();
            return View(dt);
        }


        /// <summary>
        /// Method to check balance of customer
        /// </summary>
        /// <returns>Balance</returns>

        [HttpGet]
        public ActionResult VIEWBALANCE()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VIEWBALANCE(CUSTOMER OBJ)
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
            list = objjj.info_user(accno);
            return View(list);
        }
    }
}