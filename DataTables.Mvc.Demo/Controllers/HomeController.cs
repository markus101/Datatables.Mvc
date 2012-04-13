using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTables.Mvc.Demo.Models;

namespace DataTables.Mvc.Demo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Default()
        {
            return View(GetGridModels());
        }

        public ActionResult ComplexDataProp()
        {
            return View(GetGridModels());
        }

        public ActionResult Link()
        {
            return View(GetGridModels());
        }

        public ActionResult AdvancedModel()
        {
            var model = new AdvancedModel
                            {
                                Name = "Test",
                                GridTestModels = GetGridModels()
                            };

            return View(model);
        }

        private List<GridTestModel> GetGridModels()
        {
            var models = new List<GridTestModel>();
            models.Add(new GridTestModel { Id = 1, Title = "Title1", Description = "Simple Description" });
            models.Add(new GridTestModel { Id = 2, Title = "Title2", Description = "Simple Description" });
            models.Add(new GridTestModel { Id = 3, Title = "Title3", Description = "Simple Description" });
            models.Add(new GridTestModel { Id = 4, Title = "Title4", Description = "Simple Description" });

            return models;
        }
    }
}
