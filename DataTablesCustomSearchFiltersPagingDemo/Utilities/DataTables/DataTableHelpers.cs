using System.Linq;

namespace DataTablesCustomSearchFiltersPagingDemo.Utilities.DataTables
{
    public static class DataTableHelpers
    {
        public static SearchComponents DataTableAjaxPostViewModelToComponents<T>(DataTableAjaxPostViewModel model)
        {
            SearchComponents searchComponents = ExtractSearchComponents(model);

            if (!string.IsNullOrEmpty(searchComponents.OrderBy) && typeof(T).GetProperty(searchComponents.OrderBy) == null)
                searchComponents.OrderBy = searchComponents.OrderBy;

            searchComponents.FilterProps = model.Columns
                .Where(x => x.Search?.Value != null)
                .ToDictionary(x => x.Data, x => (object)x.Search.Value);

            return searchComponents;
        }

        private static SearchComponents ExtractSearchComponents(DataTableAjaxPostViewModel model)
        {
            var searchComponents = new SearchComponents
            {
                SearchTerm = model.Search?.Value,
                Take = model.Length,
                Skip = model.Start,
                OrderBy = "",
                OrderDirection = ""
            };

            if (model.Order == null)
                return searchComponents;

            searchComponents.OrderBy = model.Columns[model.Order[0].Column].Data;
            searchComponents.OrderDirection = model.Order[0].Dir?.ToUpper() ?? "";

            return searchComponents;
        }
    }
}