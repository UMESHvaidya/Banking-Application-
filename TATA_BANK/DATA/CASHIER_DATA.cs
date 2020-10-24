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
   public class CASHIER_DATA:ICASHIER_DATA
    {
        public void INSERT_CUSTOMER(CUSTOMER OBJ)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=01VD0021643;Initial Catalog=Tcs_Group1;User ID=tcsuser1;Password=Tcs@12345");
            sqlConnection.Open();
            SqlCommand com = new SqlCommand("INSERT_CUSTOMER", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.Parameters.AddWithValue("@NAME", OBJ.NAME);
            com.Parameters.AddWithValue("@MOB_NO", OBJ.MO_NO);
            com.Parameters.AddWithValue("@AGE", OBJ.AGE);
            com.Parameters.AddWithValue("@EMAIL", OBJ.EMAIL_ID);
            com.Parameters.AddWithValue("@BALANCE", OBJ.AMOUNT);
            com.Parameters.AddWithValue("@AADHAR", OBJ.AADHAR);
            com.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<CUSTOMER> info_user(Int64 accno)
        {
            string connectionString = @"Data Source=01VD0021643;Initial Catalog=Tcs_Group1;User ID=tcsuser1;Password=Tcs@12345";
            SqlCommand cmd;
            SqlConnection conn;
            List < CUSTOMER > lst = new List<CUSTOMER>();
            DataSet ds = new DataSet();
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
            cmd.CommandText = "VIEWBALANCE";
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@ACCNO",accno );
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

        public void Deposit(CUSTOMER OBJ)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=01VD0021643;Initial Catalog=Tcs_Group1;User ID=tcsuser1;Password=Tcs@12345");
            sqlConnection.Open();
            SqlCommand com = new SqlCommand("DEPOSIT", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.Parameters.AddWithValue("@ACCNO", OBJ.ACC_NO);
            com.Parameters.AddWithValue("@AMOUNT", OBJ.AMOUNT);
            com.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void Withdraw(CUSTOMER OBJ)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=01VD0021643;Initial Catalog=Tcs_Group1;User ID=tcsuser1;Password=Tcs@12345");
            sqlConnection.Open();
            SqlCommand com = new SqlCommand("WITHDRAW", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.Parameters.AddWithValue("@ACCNO", OBJ.ACC_NO);
            com.Parameters.AddWithValue("@AMOUNT", OBJ.AMOUNT);
            com.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
