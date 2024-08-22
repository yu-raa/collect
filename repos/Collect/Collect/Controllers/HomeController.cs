using Collect.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Collect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static string Language { get; private set; }
        public static string Theme { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult GetCurrentUser()
        {
            var currUser = HttpContext.User;
            return new JsonResult(new { val = currUser.Identity });
        }

        [HttpPost]
        public ActionResult SetThemeToDark()
        {
            try
            {
                HttpContext.Response.Cookies.Delete("theme");
            }
            finally
            {
                Theme = "dark";
                HttpContext.Response.Cookies.Append("theme", Theme, new CookieOptions { Expires = DateTimeOffset.MaxValue });
            }
            return new JsonResult(null);
        }

        [HttpPost]
        public ActionResult SetThemeToLight()
        {
            try
            {
                HttpContext.Response.Cookies.Delete("theme");
            }
            finally
            {
                Theme = "light";
                HttpContext.Response.Cookies.Append("theme", Theme, new CookieOptions { Expires = DateTimeOffset.MaxValue });
            }
            return new JsonResult(null);
        }

        [HttpPost]
        public ActionResult SetLanguageToEng()
        {
            try
            {
                HttpContext.Response.Cookies.Delete("lang");
            }
            finally
            {
                Language = "en";
                HttpContext.Response.Cookies.Append("lang", Language, new CookieOptions { Expires = DateTimeOffset.MaxValue });
            }
            return new JsonResult(null);
        }

        [HttpPost]
        public ActionResult SetLanguageToRu()
        {
            try
            {
                HttpContext.Response.Cookies.Delete("lang");
            }
            finally
            {
                Language = "ru";
                HttpContext.Response.Cookies.Append("lang", Language, new CookieOptions { Expires = DateTimeOffset.MaxValue });
            }
            return new JsonResult(null);
        }

        [HttpPost]
        public ActionResult Localize(string key)
        {
            using (StreamReader r = new StreamReader($"Localization/{Language}.json"))
            {
                var json = r.ReadToEnd();
                var items = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                try
                {
                    return key is null ? new JsonResult(null) : new JsonResult(new { val = items[key] });
                }
                catch { return new JsonResult(null); }
            }
        }

        public IActionResult Index()
        {
            return View();
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
