using DL_SmartAppraisel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAppraisel.ViewModels;
using BL_SmartAppraisel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

using System.Threading.Tasks;

namespace SmartAppraisel.Controllers
{
    public class UserManagementController : Controller
    {
        BL_SmartAppraisel.BL_UserManagement userMgmtBL = new BL_SmartAppraisel.BL_UserManagement();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> AuthenticateUser(string UserId, string Password)
        {
            var user = userMgmtBL.AuthenticateUser(UserId, Password);

            if (user == null)
            {
                ViewBag.ErrorMessage = "Invalid UserId or Password";
                return View("Index");
            }

            if (user.LastPasswordDate == null)
            {
                return RedirectToAction("ChangePassword", "UserManagement");
            }


            var claims = new List<Claim>
          {
                 new Claim(ClaimTypes.Name, user.UserId),
                new Claim(ClaimTypes.NameIdentifier, user.UserId),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())   // 1002-hr
          };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

        
            var principal = new ClaimsPrincipal(identity);

           
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal
            );
    
            if (user.RoleId == 1002) {
                return RedirectToAction("Index", "Assessment");
            }
            return RedirectToAction("Index", "Home");
        }



        // GET: UserManagementController/Create
        public ActionResult Create()
        {
            var vm = new UserCreateViewModel
            {
                Roles = userMgmtBL.GetRoleDetails(),
                Designations = userMgmtBL.GetDesignationDetails()
            };
            ViewBag.Roles = vm.Roles.Select(r => new SelectListItem
            {
                Text = r.RoleName,
                Value = r.Id.ToString()
            }).ToList();

            ViewBag.Designations = vm.Designations.Select(d => new SelectListItem
            {
                Text = d.DesignationName,
                Value = d.Id.ToString()
            }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(UserCreateViewModel newUser)
        {

            if (newUser != null)
            {

                userMgmtBL.CreateUser(newUser);
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult ChangePasswordPost(string UserId, string OldPassword, string NewPassword)
        {
            if (userMgmtBL.ChangePassword(UserId, OldPassword, NewPassword))
            {
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Password is not changed";
            return View("ChangePassword");
        }

    }
}