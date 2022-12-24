using FinancialApp.Areas.Identity.Data;
using FinancialApp.Interfaces;
using FinancialApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace FinancialApp.Repositories
{
    public class CurrencyRepo : ICurrency
    {
        private readonly ApplicationDbContext _context;

        private string _errors = "";
        public CurrencyRepo(ApplicationDbContext context) // will be passed by dependency injection.
        {
            _context = context;
        }

        public bool Create(Currency currency)
        {
            try {

                //1.rule
                if (!IsDescriptionValid(currency)) return false;
                //2.rule
                if (IsItemExists(currency.Name)) return false;

                _context.Currencies.Add(currency);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed-Sql Exception Occured, Error info : " + ex.Message;
                return false;
            }

            
        }

        public bool Delete(Currency currency)
        {
            try
            {
                _context.Currencies.Attach(currency);
                _context.Entry(currency).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Delete Failed-Sql Exception Occured, Error info : " + ex.Message;
                return false;
            }
        }

        public bool Edit(Currency currency)
        {
            try
            {
                //1.rule
                if (!IsDescriptionValid(currency)) return false;
                //2.rule
                if (IsItemExists(currency.Name, currency.Id)) return false;

                _context.Currencies.Attach(currency);
                _context.Entry(currency).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Update Failed-Sql Exception Occured, Error info : " + ex.Message;
                return false;
            }
        }

        public string GetErrors()
        {
            return _errors;
        }

        private List<Currency> DoSort(List<Currency> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.Name).ToList();
                else
                    items = items.OrderByDescending(n => n.Name).ToList();
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(d => d.Description).ToList();
                else
                    items = items.OrderByDescending(d => d.Description).ToList();
            }

            return items;
        }

        public Currency GetItem(int id)
        {
           

             // Possible null assignment.
            Currency item = _context.Currencies.Where(u => u.Id == id).FirstOrDefault();
            return item;
        }

        public PaginatedList<Currency> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Currency> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.Currencies.Where(n => n.Name.Contains(SearchText) || n.Description.Contains(SearchText))
                    .ToList();
            }
            else
                items = _context.Currencies.ToList();

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<Currency> retItems = new PaginatedList<Currency>(items, pageIndex, pageSize);

            return retItems;
        }

        public bool IsCurrencyCombExists(int srcCurrencyId, int exchangeCurrencyId)
        {
            int ct = _context.Currencies.Where(n => n.Id == srcCurrencyId && n.ExchangeCurrencyId == exchangeCurrencyId).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }

        public bool IsItemExists(string name)
        {
            int ct = _context.Currencies.Where(n => n.Name.ToLower() == name.ToLower()).Count();
            if (ct > 0)
            {
                _errors = "Name " + name + " Exist already";
                return true;
            }
            else
                return false;
        }

        public bool IsItemExists(string name, int id)
        {
            int ct = _context.Currencies.Where(n => n.Name.ToLower() == name.ToLower() && n.Id != id).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }

        //Rules List
        private bool IsDescriptionValid(Currency item)
        {
            if (item.Description.Length < 4 || item.Description == null)
            {
                _errors = "Description Must be atleast 4 Characters";
                return false;
            }
            return true;
        }
        private class FinancialAppContext
        {
            internal void SaveChanges()
            {
                throw new NotImplementedException();
            }
        }
    }
}
