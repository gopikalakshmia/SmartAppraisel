using DL_SmartAppraisel.Model;
using DL_SmartAppraisel.Repository;
using SmartAppraisel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL_SmartAppraisel
{
    public class BL_UserManagement
    {
        DL_UserManagement repo = new DL_UserManagement();

        public string CreateUser(UserCreateViewModel userDetail)
        {
            return repo.CreateUser(userDetail);
        }
        public List<DesignationDetail> GetDesignationDetails()
        {
            return repo.GetDesignationDetails();
        }
        public List<RoleDetail> GetRoleDetails()
        {
            return repo.GetRoleDetails();
        }

    }
}
