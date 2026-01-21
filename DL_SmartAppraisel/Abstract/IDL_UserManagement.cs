using DL_SmartAppraisel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL_SmartAppraisel.Abstract
{
    internal interface IDL_UserManagement
    {
        public string CreateUser(UserDetail userDetail);
    }
}
