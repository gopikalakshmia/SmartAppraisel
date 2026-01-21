using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartAppraisel.Controllers
{
    public class UserManagementController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserMnagementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserMnagementController/Create
        public ActionResult Create()
        {
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
