using System.Collections.Generic;
using System.Web.Mvc;
using DataTablesCustomSearchFiltersPagingDemo.Models;
using Newtonsoft.Json;

namespace DataTablesCustomSearchFiltersPagingDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string GetEmployees()
        {
            List<Employee> employees = Employee.GetSampleEmployees();
            int recordsTotal = employees.Count;
            int recordsFiltered = employees.Count;

            return JsonConvert.SerializeObject(new { draw = 1, recordsTotal, recordsFiltered, data = employees });
        }
    }
}