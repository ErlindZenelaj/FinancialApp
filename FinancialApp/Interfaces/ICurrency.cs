using FinancialApp.Models;
using Microsoft.Data.SqlClient;

namespace FinancialApp.Interfaces
{
    public interface ICurrency
    {
        PaginatedList<Currency> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        Currency GetItem(int id); // read particular item

        bool Create(Currency currency);

        bool Edit(Currency currency);

        bool Delete(Currency currency);

        public bool IsItemExists(string name);
        public bool IsItemExists(string name, int id);


        
        public bool IsCurrencyCombExists(int srcCurrencyId, int exchangeCurrencyId);

        public string GetErrors();
        PaginatedList<Currency> GetItems(object sortedProperty, object sortedOrder, string searchText, int pg, int pageSize);
        PaginatedList<Currency> GetItems(string sortedProperty, object sortedOrder, string searchText, int pg, int pageSize);
    }

    public class PaginatedList<T>
    {
        private List<Currency> items;
        private int pageIndex;
        private int pageSize;

        public PaginatedList(List<Currency> items, int pageIndex, int pageSize)
        {
            this.items = items;
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
        }

        public object TotalRecords { get; internal set; }
    }
}
