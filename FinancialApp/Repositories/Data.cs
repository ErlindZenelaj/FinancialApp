using FinancialApp.Models;
using FinancialApp.Repositories;
using System.Data;
using System.Data.SqlClient;
using System.Configuration.Assemblies;
using System.Diagnostics.Contracts;



namespace FinancialApp.Repositories
   
{
    public class Data : IData
    {
        private string qry;

        public string ConntionString { get; set; }

        
        public Data()
        {
            ConntionString = "Server = localhost; Database = FinancialApp; Trusted_Connection = True; MultipleActiveResultSets = true ";
        }
        public void SaveBillDetails(BillDetail details)
        {
            SqlConnection con = new SqlConnection(ConntionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spt_saveEBillDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerName", details.CustomerName);
                cmd.Parameters.AddWithValue("@MobileNumber", details.MobileNumber);
                cmd.Parameters.AddWithValue("@Address", details.Address);
                cmd.Parameters.AddWithValue("@TotalAmount", details.TotalAmount);

                SqlParameter outputPara = new SqlParameter();
                outputPara.DbType = DbType.Int32;
                outputPara.Direction = ParameterDirection.Output;
                outputPara.ParameterName = "@Id";
                cmd.Parameters.Add(outputPara);
                cmd.ExecuteNonQuery();
                int id = int.Parse(outputPara.Value.ToString());
                if(details.Items.Count >0)
                {
                    SaveBillItems(details.Items, con, id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void SaveBillItems(List<Items> items, SqlConnection con, int id)
        {
            try
            {
                string gry = "insert into tbl_BillItems(ProductName,Price,Quantity) values";
                foreach (var item in items)
                {
                    qry += String.Format("('{0}', {1}, {2}, {3})", item.ProductName, item.price, item.Quantity, id);
                }
                qry = qry.Remove(qry.Length - 1);
                SqlCommand smd = new SqlCommand(qry, con);
                smd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
