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
            var employees = Employee.GetSampleEmployees();

            return JsonConvert.SerializeObject(new { draw = 1, data = employees });
        }
    }
}