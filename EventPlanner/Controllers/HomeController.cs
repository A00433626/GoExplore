using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using(GoExploreEntities goExplore = new GoExploreEntities())
            {
                var topEventList = goExplore.Event_Details.OrderByDescending(e=> e.eventId).ToList().Take(3);
                ViewBag.TopEventData = topEventList;

                var eventList = goExplore.Event_Details.OrderByDescending(e => e.eventId).ToList().Take(10);
                foreach (var item in eventList) {
                    item.imagePath = item.imagePath == null ? "~/images/autumn.jpg" : (item.imagePath.Contains("https") ? item.imagePath : "~/images/events/" + item.imagePath); 
                }
                ViewBag.EventData = eventList;
                return View();
            }
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
    }
}