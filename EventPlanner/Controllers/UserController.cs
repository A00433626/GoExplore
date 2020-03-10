using EventPlanner.Areas.Admin.Business;
using EventPlanner.Areas.Admin.Models;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (GoExploreEntities goExplore = new GoExploreEntities())
                    {
                        var userDetails = goExplore.Users.SingleOrDefault(x => x.emailId == loginModel.EmailId && x.password == loginModel.Password);
                        if (userDetails != null)
                        {
                            Session["UserId"] = userDetails.userid;
                            Session["UserName"] = userDetails.userName;
                            ViewBag.UserName = Session["UserName"].ToString();
                            ViewBag.Message = "Welcome to GoExplore.";
                            if (Session["v"] == null)
                            {
                                return RedirectToAction("Index", "Home");
                            }
                            else 
                            {
                                var v = Session["v"];
                                var s = Session["s"];
                                return RedirectToAction("Index", "Payments", new { s = s, v = v });
                            }
                        }
                        else
                        {
                            var erroMsg = "User not exist, Pleaase Create new user.";
                            return RedirectToAction("RegisterUser", "User",new { errorMessage = erroMsg});
                        }
                    }
                }
                else
                {
                    return View(loginModel);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        public ActionResult userLogout()
        {
            try
            {
                Session.Clear();
                Session.RemoveAll();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public ActionResult RegisterUser(RegistrationModel registrationModel)
        {
            try
            {
                string errorMessage = Request.QueryString["errorMessage"];
                ViewBag.Message = errorMessage;

                if (ModelState.IsValid)
                {
                    Registration reg = new Registration();
                    registrationModel.UserType = "U";
                    int _uid = reg.Createuser(registrationModel);

                    if (_uid == -1)
                    {
                        ViewBag.Message = "Email Already Exist, Please Enter some Different Email Id.";
                        return View();
                    }
                    else if (_uid == 1)
                    {
                        Session["UserId"] = _uid;
                        Session["UserName"] = registrationModel.UserName;
                        ViewBag.UserName = Session["UserName"].ToString();
                        ViewBag.Message = "Welcome " + Session["UserName"].ToString();

                        return RedirectToAction("Index", "Dashboard", new { @pageNo = 0 });
                    }
                    else
                    {
                        ViewBag.Message = "Internal Error Occurred, Please Try After Some Time.";
                        return View();
                    }

                }
                else
                {
                    return View(registrationModel);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Some Problem at User Registration, Please try again.";
                return RedirectToAction("", "");
            }
        }
        public ActionResult OrderHistory() 
        {
            using (GoExploreEntities db = new GoExploreEntities())
            {
                var userId = Convert.ToInt32(Session["UserId"]);
                var eventList = db.Bookings.Include("Event_Details").Include("Event_Details.Event_Category").Include("Event_Details.User").Where(i=>i.userId == userId && i.status == "S").ToList();
                ViewBag.eventDatas = eventList.OrderByDescending(e => e.eventId);
                ViewBag.Count = eventList.Count(); ;
                return View();
            }
        }
        public ActionResult CancelOrder(int bookingId)
        {
            using (GoExploreEntities db = new GoExploreEntities())
            {
                var booking = db.Bookings.Where(i => i.bookingId == bookingId).FirstOrDefault();
                booking.status = "D";
                //db.Bookings.Add(booking);
                db.SaveChanges();
                ViewBag.Success = 1;
                return RedirectToAction("OrderHistory","User");
            }
        }
    }
}