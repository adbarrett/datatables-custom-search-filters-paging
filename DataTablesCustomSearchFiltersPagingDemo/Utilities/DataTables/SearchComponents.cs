using System.Collections.Generic;

namespace DataTablesCustomSearchFiltersPagingDemo.Utilities.DataTables
{
    public class SearchComponents
    {
        public string SearchTerm { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public string OrderBy { get; set; }
        public string OrderDirection { get; set; }
        public Dictionary<string, object> FilterProps { get; set; }
    }
}