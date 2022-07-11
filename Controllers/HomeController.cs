using LoginFunctionality.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;

namespace LoginFunctionality.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

      
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult TestField()
        {
            return View("AlertsandToasts");
        }

        public IActionResult Index(string Username, string Password, bool RememberMe)
        {
            var credentials = new Credentials() { Username = Username, Password = Password, RememberMe = RememberMe};
            if (Request.Cookies["Name"] != null & Request.Cookies["Password"] != null & Request.Cookies["RememberMe"] != null)
            {
                ViewBag.Name = Request.Cookies["Name"];
                ViewBag.Password = Request.Cookies["Password"];
                ViewBag.RememberMe = Request.Cookies["RememberMe"];
               
            }
            return View("Login");
        }

        [HttpPost]
        public IActionResult Index(string Username, string Password, bool RememberMe, bool isLoggedIn)
        {
            
            var credentials = new Credentials() { Username = Username, Password = Password, RememberMe = RememberMe, IsLoggedIn = isLoggedIn};
            HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(credentials));

            var cred = JsonConvert.DeserializeObject<Credentials>(HttpContext.Session.GetString("UserSession"));


            ViewBag.Name = cred.Username;
            ViewBag.Password = cred.Password;
            ViewBag.RememberMe = cred.RememberMe;
            ViewBag.LoggedIn = cred.IsLoggedIn;

            if (cred.RememberMe == true)
            {
                CookieOptions options = new();

                //Sets the expiration date for the cookies
                options.Expires = DateTime.Now.AddDays(30);

                //Saves the user data into cookies
                Response.Cookies.Append("Name", cred.Username, options);
                Response.Cookies.Append("Password", cred.Password, options);
                Response.Cookies.Append("RememberMe", cred.RememberMe.ToString(), options);
                
                
            }
            else
            {
                //Deletes all cookie data 
                Response.Cookies.Delete("Name");
                Response.Cookies.Delete("Password");
                Response.Cookies.Delete("RememberMe");
            }

            //Sets the loggedin variable to true
            ViewBag.LoggedIn = true;
            return View("Privacy");


        }

        [HttpPost]
        public IActionResult LogOut(string Username, string Password, bool RememberMe)
        {
            //Clears the session when logged out
            HttpContext.Session.Clear();
            ViewBag.LoggedIn = false;
            //Links the control names with the model names
            var credentials = new Credentials() { Username = Username, Password = Password, RememberMe = RememberMe };

            //Checks if the cookies are not null
            if (Request.Cookies["Name"] != null & Request.Cookies["Password"] != null & Request.Cookies["RememberMe"] != null)
            {
                ViewBag.Name = Request.Cookies["Name"];
                ViewBag.Password = Request.Cookies["Password"];
                ViewBag.RememberMe = Request.Cookies["RememberMe"];

            }
            return View("Login");
        }


        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}