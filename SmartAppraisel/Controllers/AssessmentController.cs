using DL_SmartAppraisel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAppraisel.ViewModels;
using BL_SmartAppraisel;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace SmartAppraisel.Controllers
{
    public class AssessmentController : Controller
    {
        BL_SmartAppraisel.BL_AssessmentManagement AssessmentMgmtBL = new BL_SmartAppraisel.BL_AssessmentManagement();

        public ActionResult Index()
        {
            var assessments = AssessmentMgmtBL.GetAllAssessments();
            return View(assessments);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

    [HttpPost]
        public ActionResult CreateAssessment(AssessmentDetail newAssessmentDetail)
        {
            if (newAssessmentDetail != null)
            {
                AssessmentMgmtBL.CreateAssessment(newAssessmentDetail);
                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public ActionResult CreateResponse(int AssessmentID,int questionID=1)
        {
            ViewBag.AssessmentID = AssessmentID;
            ViewBag.QuestionID = questionID;
            ViewBag.Competencies = new SelectList(AssessmentMgmtBL.GetAllCompetencies(), "CompID", "CompName");
            return View();
        }
        

        public string CreateAssessmentResponse(AssessmentResponse newAssessmentResponse)
        {
            if (newAssessmentResponse != null)
            {
                return AssessmentMgmtBL.CreateAssessmentResponse(newAssessmentResponse);
            }

            return "Invalid Response";
        }

        
    }
}