using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //View - 2 types - Strongly typed view and weakly typed view
        //The data that you return back to your view can be strongly typed or weakly typed
        //Strongly typed view - Model is passed from the controller action to the view - Model(Collections,Database)
        //Weaking typed view - ViewBag, ViewData, TempData
        //ViewBag - Dynamic object to pass data from controller to view
        //ViewData - Dictionary object to pass data from controller to view - ViewData["Key"] = value;
        public IActionResult Details()
        {
            var emp = new Employee // Model
            {
                Id = 1,
                Name = "John Doe"
            };
            return View(emp); // Id=1, Name=John Doe (Action-Details is returning the model emp to the view)
        }

        [Route("employee/weaklydemo")]
        public IActionResult WeaklyDemo()
        {
            ViewBag.Message = "Hello from ViewBag";
            ViewData["Info"] = "Hello from ViewData";
            TempData["Notice"] = "Hello from TempData";
            return View();
        }

        [Route("employee/employeelist")]
        public IActionResult EmployeeList()
        {
            var employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "John" },
        new Employee { Id = 2, Name = "Anna" }
    };
            return View(employees);
        }

    }
}
