using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventPlanner.Areas.Admin.Models;
using EventPlanner.Models;

namespace EventPlanner.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
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
                            //goExplore.Dispose();
                            return RedirectToAction("Index", "Dashboard", new { @pageNo = 0 });
                            //return RedirectToActionPermanent()
                        }
                        else
                        {
                            ViewBag.Message = "User not exist, Pleaase Create new user.";
                            return RedirectToAction("Index", "Registration");
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
                return RedirectToAction("Index", "../Home");
            }catch(Exception ex)
            {
                return View();
            }

        }
    }
}