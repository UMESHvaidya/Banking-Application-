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
    public class LOGIN_BUSINESS:ILOGINBUSINESS
    {
        private ILOGINDATA OBJECT = new LOGIN_DATA();
        public DataSet LOGIN(LOGIN_PROPERTY OBJ)
        {
            DataSet ds = new DataSet();
            ds = OBJECT.LOGIN(OBJ);
            return ds;
        }
        public List<CUSTOMER> info(Int32 accno)
        {
            List<CUSTOMER> dt = OBJECT.info(accno);
            return dt;
        }
    }
}
