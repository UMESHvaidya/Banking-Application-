using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public  class Fund_Transfer
    {
        public int FROM_ACCNO { get; set; }
        public int TO_ACCNO { get; set; }
        public string TRANSACTION_TYPE { get; set; }
        public DateTime DATE { get; set; }
        public int AMOUNT { get; set; }
    }
}
