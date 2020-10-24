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
   public class CUSTOMER_BUSINESS:ICUSTOMER_BUSINESS
    {
        private CUSTOMER_DATA OBJECT = new CUSTOMER_DATA();
        public void FUNDTRANSFER(Fund_Transfer OBJ)
        {
            OBJECT.FUNDTRANSFER(OBJ);
        }
        public List<Fund_Transfer> ViewDataBase()
        {
            List<Fund_Transfer> dt = OBJECT.ViewDataBase();
            return dt;
        }

    }
}

