using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODELS;
using System.Threading.Tasks;
using System.Data;
namespace IDENTITY
{
    public  interface ICASHIER_BUSINESS
    {
        void INSERT_CUSTOMER(CUSTOMER OBJ);
        //  void MANAGE_ACCOUNT(CUSTOMER OBJ);
        List<CUSTOMER> info_user(Int64 accno);
        void Deposit(CUSTOMER OBJ);
        void Withdraw(CUSTOMER OBJ);
    }
}
