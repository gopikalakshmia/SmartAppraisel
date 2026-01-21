using DL_SmartAppraisel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL_SmartAppraisel.Repository
{
    public class DL_UserManagement
    {
        SmartAppraiselDbContext db = new SmartAppraiselDbContext();

        public string CreateUser(UserDetail userDetail)
        {
            if (userDetail != null)
            {
                db.UserDetails.Add(userDetail);
                db.SaveChanges();
            }
            return "not created";
        }


    }
}
