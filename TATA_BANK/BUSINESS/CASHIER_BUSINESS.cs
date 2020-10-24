using System;
using System.Collections.Generic;
using System.Linq;
using DATA;
using MODELS;
using IDENTITY;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BUSINESS
{
    public class CASHIER_BUSINESS:ICASHIER_BUSINESS
    {
        private CASHIER_DATA OBJECT = new CASHIER_DATA();
        public void INSERT_CUSTOMER(CUSTOMER OBJ)
        {
            OBJECT.INSERT_CUSTOMER(OBJ);
        }
        //public void MANAGE_ACCOUNT(CUSTOMER OBJ)
        //{
        //    OBJECT.MANAGE_ACCOUNT(OBJ);
        //}
        public List<CUSTOMER> info_user(Int64 accno)
        {
            List<CUSTOMER> dt = OBJECT.info_user(accno);
            return dt;
        }
        public void Deposit(CUSTOMER OBJ)
        {
            OBJECT.Deposit(OBJ);
        }
        public void Withdraw(CUSTOMER OBJ)
        {
            OBJECT.Withdraw(OBJ);
        }
    }
}
