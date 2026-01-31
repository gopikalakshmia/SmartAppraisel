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
                newUserDb.RoleId = userDetail.RoleId;
                newUserDb.UserId = userDetail.UserId;
                newUserDb.Password = userDetail.Password;
                newUserDb.Email = userDetail.Email;
                newUserDb.LastPasswordDate = null;
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

        public UserDetail AuthenticateUser(string UserId,string Password)
        {
            var user = db.UserDetails.FirstOrDefault(u => u.UserId == UserId && u.Password == Password);
            return user;
        }

        public bool ChangePassword(string UserId, string OldPassword, string NewPassword)
        {
            var user = db.UserDetails.FirstOrDefault(u => u.UserId == UserId && u.Password == OldPassword);
            if (user != null)
            {
                user.Password = NewPassword;
                user.LastPasswordDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

    }
}