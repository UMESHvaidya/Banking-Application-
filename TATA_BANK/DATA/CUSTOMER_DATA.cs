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
   public class CUSTOMER_DATA
    {
        public void FUNDTRANSFER(Fund_Transfer OBJ)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=01VD0021643;Initial Catalog=Tcs_Group1;User ID=tcsuser1;Password=Tcs@12345");
            sqlConnection.Open();
            SqlCommand com = new SqlCommand("TRANSFERMONEY", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.Parameters.AddWithValue("@ACCNO", OBJ.FROM_ACCNO);
            com.Parameters.AddWithValue("@TO_ACCNO", OBJ.TO_ACCNO);
            com.Parameters.AddWithValue("@TRANSACTIONTYPE", OBJ.TRANSACTION_TYPE);
            com.Parameters.AddWithValue("@AMOUNT", OBJ.AMOUNT);
            com.ExecuteNonQuery();
            sqlConnection.Close();
        }



        public List<Fund_Transfer> ViewDataBase()
        {
            List<Fund_Transfer> dt = new List<Fund_Transfer>();
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=01VD0021643;Initial Catalog=Tcs_Group1;User ID=tcsuser1;Password=Tcs@12345");
            if (sqlConnection.State == ConnectionState.Closed)
                sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("VIEWMINISTATEMENT", sqlConnection);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var obj = new Fund_Transfer();
                obj.FROM_ACCNO = Convert.ToInt32(rdr["ACCNO"]);
                obj.TO_ACCNO = Convert.ToInt32(rdr["TO_ACCNO"]);
                obj.TRANSACTION_TYPE = rdr["TRANSACTIONTYPE"].ToString();
                obj.DATE = Convert.ToDateTime(rdr["SYS_DATE"]);
                obj.AMOUNT = Convert.ToInt32(rdr["AMOUNT"]);
                dt.Add(obj);
            }
            sqlConnection.Close();
            return dt;
        }

    }
}
