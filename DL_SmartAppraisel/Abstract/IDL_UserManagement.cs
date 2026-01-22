using DL_SmartAppraisel.Model;
using SmartAppraisel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL_SmartAppraisel.Abstract
{
    internal interface IDL_UserManagement
    {
        public string CreateUser(UserCreateViewModel userDetail);
        public List<RoleDetail> GetRoleDetails();
        public List<DesignationDetail> GetDesignationDetails();
    }
}
