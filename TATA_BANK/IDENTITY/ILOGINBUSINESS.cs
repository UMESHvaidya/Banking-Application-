using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODELS;
using System.Threading.Tasks;
using System.Data;

namespace IDENTITY
{
    public interface ILOGINBUSINESS
    {
        DataSet LOGIN(LOGIN_PROPERTY OBJ);
        List<CUSTOMER> info(Int32 accno);
    }
}
