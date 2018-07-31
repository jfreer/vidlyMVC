using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        // ActionResult is super class
        public ViewResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            return View(movie);
            // return Content("Hello World")
            // return HttpNotFound()
            // return new EmptyResult()
            // return RedirectToAction("Index(Action)", "Home(Controller)", new { page = 1, sortby = "name" })
        }

        // movies/edit/1 or movies/edit?id=1
        // id is defined as the default param name in the route config
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // movies or movies/pageIndex=1 or movies/sortBy=Name or movies/pageIndex=1&sortBy=Name
        // int can be made nullable, string is by definition nullable
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue) //is nullable value of correct type
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy)) //null, empty or only whitespace
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}
