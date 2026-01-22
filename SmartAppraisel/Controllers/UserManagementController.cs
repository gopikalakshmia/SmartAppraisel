using DL_SmartAppraisel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAppraisel.ViewModels;
using BL_SmartAppraisel;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace SmartAppraisel.Controllers
{
    public class UserManagementController : Controller
    {
       BL_SmartAppraisel.BL_UserManagement userMgmtBL = new BL_SmartAppraisel.BL_UserManagement();

        public ActionResult Index()
        {
            return View();
        }

        // GET: UserManagementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public  ActionResult CreateUser(UserCreateViewModel newUser)
        {

            if ( newUser!=null) {

                userMgmtBL.CreateUser(newUser);
                return RedirectToAction("Index");
            }
           
            return View();
        }

        // POST: UserMnagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserMnagementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserMnagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserMnagementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserMnagementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
