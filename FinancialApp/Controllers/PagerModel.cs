namespace FinancialApp.Controllers
{
    internal class PagerModel
    {
        private object totalRecords;
        private int pg;
        private int pageSize;

        public PagerModel(object totalRecords, int pg, int pageSize)
        {
            this.totalRecords = totalRecords;
            this.pg = pg;
            this.pageSize = pageSize;
        }

        public string SortExpression { get; internal set; }
    }
}