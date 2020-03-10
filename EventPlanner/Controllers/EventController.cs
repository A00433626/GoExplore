using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventPlanner.Areas.Admin.Models;
using EventPlanner.Helper;
using Newtonsoft.Json;

namespace EventPlanner.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult EventList()
        {
            //ViewBag.Title = "Event List.";
            using (GoExploreEntities db = new GoExploreEntities())
            {
                //var eventList = db.Event_Details.ToList().Skip(0).Take(10);
               

                var eventListCount = db.Event_Details.ToList().Count();
                ViewBag.ec_Count = eventListCount;

                var upcomingEvent = db.Event_Details.Include("Event_Category").Include("User").Where(e => e.eventDate > DateTime.Today).ToList().Take(10);
                ViewBag.upcomingEvent = upcomingEvent.OrderByDescending(e => e.eventId);

                var upcomingEventCount = db.Event_Details.ToList().Count();
                ViewBag.ue_Count = upcomingEventCount;

                return View();
            }
        }

        public ActionResult event_detail(int eventId)
        {
            using(GoExploreEntities goExplore = new GoExploreEntities())
            {
                EventDetail eventDetailModel = new EventDetail();
                var eventDetailData =goExplore.Event_Details.Where(e => e.eventId == eventId).FirstOrDefault();

                eventDetailModel.eventId = eventDetailData.eventId;
                eventDetailModel.categoryId = eventDetailData.categoryId;
                eventDetailModel.eventName = eventDetailData.eventName;
                eventDetailModel.eventDescription = eventDetailData.eventDescription;
                eventDetailModel.venue = eventDetailData.venue;
                eventDetailModel.eventDate = eventDetailData.eventDate;
                eventDetailModel.organizerId = eventDetailData.organizerId;
                eventDetailModel.ticketPrice = eventDetailData.ticketPrice;
                eventDetailModel.totalSeats = eventDetailData.totalSeats;
                eventDetailModel.imagePath = eventDetailData.imagePath;


                var eventDetailList = goExplore.Event_Details.OrderByDescending(e => e.eventId).ToList().Take(10);
                ViewBag.EventList = eventDetailList;
                return View(eventDetailModel);
            }
        }

        [HttpPost]
        public ActionResult SearchEvents(string venue)
        {
            using (GoExploreEntities goExplore = new GoExploreEntities())
            {
                var filteredList = goExplore.Event_Details.Where(e => e.City.Contains(venue)).ToList().Take(5);
                EventListDetails eventListDetails = new EventListDetails();
                eventListDetails.Events = new List<Events>();
                foreach (var item in filteredList) 
                {
                    Events events = new Events();
                    events.categoryId = item.categoryId;
                    events.City = item.City;
                    events.eventDate = item.eventDate;
                    events.eventDescription = item.eventDescription;
                    events.eventId = item.eventId;
                    events.eventName = item.eventName;
                    events.imagePath = item.imagePath;
                    events.organizerId = item.organizerId;
                    events.ticketPrice = item.ticketPrice;
                    events.totalSeats = item.totalSeats;
                    events.venue = item.venue;
                    eventListDetails.Events.Add(events);
                }
                string data = JsonConvert.SerializeObject(eventListDetails.Events);
                return Json(data);
            }
        }
        [HttpGet]
        public ActionResult _eventPartial(string venue)
        {
            using (GoExploreEntities db = new GoExploreEntities())
            {
                if (venue == null || venue.Length <= 0)
                {
                    var currnetEvent = db.Event_Details.Include("Event_Category").Include("User").ToList().Take(10);
                    ViewBag.currnetEvent = currnetEvent.OrderByDescending(e => e.eventId);
                }
                else 
                {
                    var currnetEvent = db.Event_Details.Include("Event_Category").Include("User").Where(e => e.City.Contains(venue)).ToList().Take(10);
                    ViewBag.currnetEvent = currnetEvent.OrderByDescending(e => e.eventId);
                }
            }
            return PartialView("~/Views/Event/_eventPartial.cshtml");
        }
    }

}