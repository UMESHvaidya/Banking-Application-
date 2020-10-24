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
    public class HomeController : Controller
    {
        private  ILOGINBUSINESS loginbusiness = new LOGIN_BUSINESS();
        private ITRANSFERBUSINESS TRANSFER = new TRANSFER_BUSINESS();
        private CASHIER_BUSINESS cashierbusiness = new CASHIER_BUSINESS();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Method to Login Into the Website  
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult LOGIN()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LOGIN(LOGIN_PROPERTY obj)
        {
            if (Convert.ToBoolean(obj.USERNAME == null) || Convert.ToBoolean(obj.PASSWORD == null))
            {
                ModelState.AddModelError("", "PLEASE ENTER  VALID USERNAME AND PASSWORD");
                return View();
            }
            else {

                DataSet ds = new DataSet();
                ds = loginbusiness.LOGIN(obj);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    Session["USERNAME"] = ds.Tables[0].Rows[0][0].ToString();
                    Session["ROLID"] = ds.Tables[0].Rows[0][1].ToString();
                    int N = Convert.ToInt16(Session["ROLID"]);
                    if (N == 1)
                    {
                        return RedirectToAction("Customer", "Customer");
                    }
                    if (N == 2)
                    {
                        return RedirectToAction("Cashier", "Cashier");
                    }
                    if (N == 3)
                    {
                        return RedirectToAction("BankManager", "BankManager");
                    }
                }
            }           
            return View();
        }
        [HttpGet]
        public ActionResult ENTRY()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ENTRY(CUSTOMER OBJ)
        {
            //CUSTOMER OBJ = new CUSTOMER();
            string url = string.Format("/Home/info?accno={0}", OBJ.ACC_NO);
            return Redirect(url);

        }
        [HttpGet]
        public ActionResult info()
        {
            List<CUSTOMER> list = new List<CUSTOMER>();
            CUSTOMER OBJ = new CUSTOMER();
            DataSet dt = new DataSet();
            OBJ.ACC_NO = int.Parse(Request.QueryString["accno"]);
            Int32 accno = Convert.ToInt32(OBJ.ACC_NO);
            list = loginbusiness.info(accno);
            return View(list);
        }


        /// <summary>
        /// Method To Logout from the Account
        /// </summary>
        /// <returns></returns>


        public ActionResult LOGOUT()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LOGIN", "Home");
        
        }
        public ActionResult FAQ()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Complaint()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Card()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
