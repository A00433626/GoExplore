using EventPlanner.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventPlanner.Models;

namespace EventPlanner.Areas.Admin.Business
{
    public class Registration
    {
        public int Createuser(RegistrationModel registrationModel)
        {
            using(GoExploreEntities goExplore = new GoExploreEntities())
            {
                int UID = 0;
                User existing =  goExplore.Users.FirstOrDefault(u => u.emailId == registrationModel.EmailId);
                if(existing == null)
                {
                    User users = new User();
                    users.userid = 0;
                    users.userName = registrationModel.UserName;
                    users.emailId = registrationModel.EmailId;
                    users.userType = registrationModel.UserType;
                    users.password = registrationModel.Password;
                    goExplore.Users.Add(users);
                    UID = goExplore.SaveChanges();
                }
                else
                {
                    UID = -1; 
                }
                return UID;
            }
        }
    }
}