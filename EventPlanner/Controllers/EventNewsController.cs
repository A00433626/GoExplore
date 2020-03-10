using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Controllers
{
    public class EventNewsController : Controller
    {
        // GET: EventNews
        public ActionResult News()
        {
            ViewBag.ClassName = "events-news-page";
            return View();
        }


    }
}