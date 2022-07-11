using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using LoginFunctionality.Models;

namespace LoginFunctionality.Controllers
{
    public class CredentialController : Controller
    {
        public IActionResult Index()
        {
            //Get Session Info
            var credential = JsonConvert.DeserializeObject<Credentials>(HttpContext.Session.GetString("UserSession"));
            return View(credential);
        }
    }
}
