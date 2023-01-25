using FinancialApp.Models;
using System.Data.SqlClient;

namespace FinancialApp.Repositories
{
    public interface IData
    {
        void SaveBillDetails(BillDetail details);
        void SaveBillItems(List<Items> items, SqlConnection con, int id);

        List<BillDetail> GetAllDetail();

        BillDetail GetDetail(int Id);
    }
}
