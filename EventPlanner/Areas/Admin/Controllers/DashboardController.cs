using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EventPlanner.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult Index(int pageNo)
        {
            try
            {
                if (Session["UserId"] != null)
                {
                    using (GoExploreEntities db = new GoExploreEntities())
                    {
                        //var eventList = db.Event_Details.ToList().Skip(0).Take(10);
                        var eventList = db.Event_Details.Include("Event_Category").Include("User").ToList().Skip(pageNo * 10).Take(10);
                        ViewBag.eventDatas = eventList.OrderByDescending(e=> e.eventId);
                        ViewBag.UserName = Session["UserName"].ToString();

                        var eventListCount = db.Event_Details.ToList().Count();
                        ViewBag.Count = eventListCount;
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login");

                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult PagingnationEvent(int pageNo)
        {
            try
            {
                if (Session["UserId"] != null)
                {
                    using (GoExploreEntities db = new GoExploreEntities())
                    {
                        var eventList = db.Event_Details.ToList().Skip(pageNo * 10).Take(10);
                        ViewBag.eventDatas = eventList.OrderByDescending(e => e.eventId);
                        ViewBag.UserName = Session["UserName"].ToString();
                        return View();
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login");

                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult AddEvent()
        {
            try
            {
                if (Session["UserId"] != null)
                {
                    using (GoExploreEntities db = new GoExploreEntities())
                    {
                        var categoryList = db.Event_Category.ToList();
                        SelectList catSelectList = new SelectList(categoryList, "CategoryId", "CategoryName");
                        ViewBag.CategoryData = catSelectList;

                        var userList = db.Users.ToList();
                        SelectList userSelect = new SelectList(userList, "UserId", "UserNAme");
                        ViewBag.UserData = userSelect;
                        ViewBag.UserName = Session["UserName"].ToString();
                    }
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Login");

                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult SaveEvent(Event_Details event_Details, HttpPostedFileBase ImagePath)
        {
            var allowedExtensions = new[] { ".Jpg", ".png", ".jpg", "jpeg" };
            using (GoExploreEntities goExplore = new GoExploreEntities()) {

                int _rownumner = goExplore.Event_Details.Count();

                var fileName = Path.GetFileName(ImagePath.FileName);
                var ext = Path.GetExtension(ImagePath.FileName);

                string name = Path.GetFileNameWithoutExtension(fileName);
                //string myfile = name +"_"+ _rownumner.ToString() + ext;
                string myfile = "eImg_" + _rownumner.ToString() + ext;
                var path = Path.Combine(Server.MapPath("~/images/"), myfile);
                ImagePath.SaveAs(path);

                Event_Details _event_Details = new Event_Details();
                _event_Details.categoryId = event_Details.categoryId;
                _event_Details.eventName = event_Details.eventName;
                _event_Details.eventDescription = event_Details.eventDescription;
                _event_Details.eventDate = event_Details.eventDate;
                _event_Details.venue = event_Details.venue;
                _event_Details.organizerId = event_Details.organizerId;
                //_event_Details.i = myfile;

                goExplore.Event_Details.Add(_event_Details);
                goExplore.SaveChanges();

                int newEventId = event_Details.eventId;
                return RedirectToAction("Index", "Dashboard", new { @pageNo=0});
            }
            
        }
    }
}