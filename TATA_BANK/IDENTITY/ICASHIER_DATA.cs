using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODELS;
using System.Threading.Tasks;
using System.Data;

namespace IDENTITY
{
   public interface ICASHIER_DATA
    {
        void INSERT_CUSTOMER(CUSTOMER obj );
      //  void MANAGE_ACCOUNT(CUSTOMER OBJ);
        List<CUSTOMER> info_user(Int64 accno);
        void Deposit(CUSTOMER OBJ);
        void Withdraw(CUSTOMER OBJ);
    }
}
