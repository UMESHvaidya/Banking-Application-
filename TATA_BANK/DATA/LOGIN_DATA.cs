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
    public class LOGIN_DATA:ILOGINDATA
    {
        public DataSet LOGIN(LOGIN_PROPERTY OBJ)
        {
            DataSet ds = new DataSet();
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=01VD0021643;Initial Catalog=Tcs_Group1;User ID=tcsuser1;Password=Tcs@12345");
            sqlConnection.Open();
            SqlCommand com = new SqlCommand("LOGIN_METHOD", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.Parameters.AddWithValue("@USERNAME", OBJ.USERNAME);
            com.Parameters.AddWithValue("@USERPASSWORD", OBJ.PASSWORD);
            da.Fill(ds);
            return ds;
          
        }
        public List<CUSTOMER> info(Int32 accno)
        {
            string connectionString = @"Data Source=01VD0021643;Initial Catalog=Tcs_Group1;User ID=tcsuser1;Password=Tcs@12345";
            SqlCommand cmd;
            SqlConnection conn;
            List<CUSTOMER> lst = new List<CUSTOMER>();
            DataSet ds = new DataSet();
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandText = "VIEWBALANCE";
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@ACCNO", accno);
            da.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lst.Add(new CUSTOMER()
                {
                    ACCNO = Convert.ToInt32(dr["ACCNO"]),
                    NAME = dr["NAME"].ToString(),
                    AMOUNT = float.Parse(dr["BALANCE"].ToString())
                });
            }
            return lst;

        }
    }
}
