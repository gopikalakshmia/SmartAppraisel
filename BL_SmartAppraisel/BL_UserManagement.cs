using DL_SmartAppraisel.Model;
using DL_SmartAppraisel.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL_SmartAppraisel
{
    public class BL_UserManagement
    {
        DL_UserManagement repo = new DL_UserManagement();

        public string CreateUser(UserDetail userDetail)
        {
            return repo.CreateUser(userDetail);
        }

    }
}
