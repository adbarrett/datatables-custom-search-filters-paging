using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataTablesCustomSearchFiltersPagingDemo.Models;
using DataTablesCustomSearchFiltersPagingDemo.Utilities.DataTables;
using Newtonsoft.Json;

namespace DataTablesCustomSearchFiltersPagingDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string GetEmployees(DataTableAjaxPostViewModel model)
        {
            SearchComponents searchComponents = DataTableHelpers.DataTableAjaxPostViewModelToComponents<Employee>(model);
            Column dateOfBirthColumn = model.Columns.Single(c => c.Data == "DateOfBirth");
            searchComponents.FilterProps["DateOfBirth"] = new Dictionary<string, DateTime?>
            {
                { "MinDate", dateOfBirthColumn.DateSearch.MinDate },
                { "MaxDate", dateOfBirthColumn.DateSearch.MaxDate }
            };

            int recordsTotal = Employee.TotalCount();
            int recordsFiltered = Employee.FilteredCount(searchComponents.SearchTerm, searchComponents.FilterProps);

            IEnumerable<Employee> employees = Employee.SearchEmployees(searchComponents.SearchTerm,
                searchComponents.Take, searchComponents.Skip, searchComponents.OrderBy, searchComponents.OrderDirection,
                searchComponents.FilterProps);

            return JsonConvert.SerializeObject(new { model.Draw, recordsTotal, recordsFiltered, data = employees });
        }
    }
}