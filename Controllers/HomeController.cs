using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MVCDemo.Controllers
{
    // MVC Web Application Controller - Tha base class is Controller
    public class HomeController : Controller
    {
        // Action Method - Handles HTTP GET requests for the root URL
        //IActionResult is the return type for action methods in MVC
        public IActionResult Index()
        {
            //View - User Interface
            //Views in .net core mvc are stored in the Views folder
            //They are in the for of .cshtml files - Razor View Engine
            //Combination of HTML and C# - Razor View Syntax
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Toyota() 
        { 
            return View();
        }

    }
}
