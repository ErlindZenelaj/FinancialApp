using Microsoft.Data.SqlClient;

namespace FinancialApp.Controllers
{
    internal class SortModel
    {
        public string SortedProperty { get; internal set; }
        public SortOrder SortedOrder { get; internal set; }

        internal void AddColumn(string v)
        {
            throw new NotImplementedException();
        }

        internal void ApplySort(string sortExpression)
        {
            throw new NotImplementedException();
        }
    }
}