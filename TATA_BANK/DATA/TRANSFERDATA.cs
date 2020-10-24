using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS;
using IDENTITY;
using System.Data.SqlClient;
using System.Data;

namespace DATA
{
    public class TRANSFERDATA:ITRANSFERDATA
    {
        public void FUNDTRANSFER(Fund_Transfer OBJ)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=01VD0021643;Initial Catalog=Tcs_Group1;User ID=tcsuser1;Password=Tcs@12345");
            sqlConnection.Open();
            SqlCommand com = new SqlCommand("TRANSFERMONEY", sqlConnection);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            com.Parameters.AddWithValue("@ACCNO", OBJ.FROM_ACCNO);
            com.Parameters.AddWithValue("@AMOUNT", OBJ.AMOUNT);
            com.Parameters.AddWithValue("@TRANSACTIONTYPE", OBJ.TRANSACTION_TYPE);
            com.Parameters.AddWithValue("@TO_ACCNO", OBJ.TO_ACCNO);
            com.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}