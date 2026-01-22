using DL_SmartAppraisel.Model;
using SmartAppraisel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL_SmartAppraisel.Repository
{
    public class DL_UserManagement
    {
        SmartAppraiselDbContext db = new SmartAppraiselDbContext();

        public string CreateUser(UserCreateViewModel userDetail)
        {
            if (userDetail != null)
            {
                UserDetail newUserDb = new UserDetail();
                newUserDb.DesgnId = userDetail.DesgnId;
                newUserDb.ProjectId = userDetail.RoleId;
                newUserDb.UserId = userDetail.UserId;
                newUserDb.Password = userDetail.Password;

                db.UserDetails.Add(newUserDb);
                db.SaveChanges();
            }
            return "not created";
        }
        public List<RoleDetail> GetRoleDetails()
        {
            return db.RoleDetails.ToList();
        }

        public List<DesignationDetail> GetDesignationDetails()
        {
            return db.DesignationDetails.ToList();
        }

    }
}
