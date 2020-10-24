using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODELS;
using System.Threading.Tasks;

namespace IDENTITY
{
    public interface ICUSTOMER_BUSINESS
    {
        void FUNDTRANSFER(Fund_Transfer OBJ);
        List<Fund_Transfer> ViewDataBase();
       // List<CUSTOMER> BALANCEINFO(CUSTOMER OBJ);
    }
}

