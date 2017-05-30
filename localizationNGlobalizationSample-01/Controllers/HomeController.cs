using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace localizationNGlobalizationSample_01.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        public static List<Person> people = new List<Person> { };
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Person()
        {
            return View(people);
        }

        public ActionResult Create()
        {

            return View(new Person { });
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {

            if (ModelState.IsValid)
            {
                people.Add(person);

                return RedirectToAction("Person");
            }

            return View();
        }
    }
}