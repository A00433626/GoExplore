using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventPlanner.Areas.Admin.Business;
using EventPlanner.Areas.Admin.Models;
using EventPlanner.Models;

namespace EventPlanner.Areas.Admin.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Admin/Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RegistrationModel registrationModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Registration reg = new Registration();
                    registrationModel.UserType = "O";
                    int _uid = reg.Createuser(registrationModel);

                    if (_uid == -1)
                    {
                        ViewBag.Message = "Email Already Exist, Please Enter some Different Email Id.";
                        return View();
                    }
                    else if(_uid == 1)
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
                
            }catch(Exception ex)
            {
                ViewBag.Message = "Some Problem at User Registration, Please try again.";
                return RedirectToAction("", "");
            }
        }
    }
}