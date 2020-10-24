using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODELS;
using System.Threading.Tasks;
using System.Data;

namespace IDENTITY
{
    public interface IMANGER_DATA
    {
        List<CUSTOMER> VIEWMANAGER();
    }
}
