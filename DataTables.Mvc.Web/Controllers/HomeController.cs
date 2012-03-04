using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DataTables.Mvc.Web.Models;

namespace DataTables.Mvc.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Test()
        {
            var model = new List<TestGridModel>
                            {
                                new TestGridModel{ Id = 1, Title = "Title1", Description = "This is a description" },
                                new TestGridModel{ Id = 2, Title = "Title2", Description = "This is a description" },
                                new TestGridModel{ Id = 3, Title = "Title3", Description = "This is a description" },
                                new TestGridModel{ Id = 4, Title = "Title4", Description = "This is a description" }
                            };

            var serialized = new JavaScriptSerializer().Serialize(model);

            return View((object)serialized);
        }
    }
}
