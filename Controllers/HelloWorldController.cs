using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


namespace MacLibrary.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {

            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name, int ID = 12)
        {

            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
            //return "This is the Welcome action method...";
        }

        public IActionResult Account()
        {
            return View();
        }
    }
}