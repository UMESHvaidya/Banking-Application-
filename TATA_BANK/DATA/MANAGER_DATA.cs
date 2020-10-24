using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODELS;
using IDENTITY;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DATA
{
    class MANAGER_DATA
    {
        public List<CUSTOMER> VIEWMANAGER()
        {
            List<CUSTOMER> dt = new List<CUSTOMER>();
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=01VD0021643;Initial Catalog=Tcs_Group1;User ID=tcsuser1;Password=Tcs@12345");
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("VIEWMANAGER", sqlConnection);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var obj = new CUSTOMER();
                obj.ACC_NO = Convert.ToInt32(rdr["ACCNO"]);
                obj.NAME =  (rdr["TO_ACCNO"]).ToString();
                obj.MO_NO = Convert.ToInt32(rdr["MOB_NO"]);
                obj.AGE = Convert.ToInt32(rdr["AGE"]);
                obj.EMAIL_ID = (rdr["EMAIL"]).ToString();
                obj.AMOUNT = Convert.ToInt32(rdr["AMOUNT"]);
                obj.AADHAR = Convert.ToInt32(rdr["AADHAR"]);
                dt.Add(obj);
            }
            sqlConnection.Close();
            return dt;

        }
    }
}
