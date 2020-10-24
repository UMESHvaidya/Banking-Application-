using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DATA;
using IDENTITY;
using MODELS;
using System.Threading.Tasks;

namespace BUSINESS
{
    public class TRANSFER_BUSINESS :ITRANSFERBUSINESS
    {
        private TRANSFERDATA OBJECT = new TRANSFERDATA();
        public void FUNDTRANSFER(Fund_Transfer OBJ)
        {
            OBJECT.FUNDTRANSFER(OBJ);
        }
    }
}
