using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMovie.Controllers
{
    public class HelloWorldController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public string Welcome(string name, int ID = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + ", ID is: " + ID);
        }
    }
}