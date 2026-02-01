using DL_SmartAppraisel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAppraisel.ViewModels;
using BL_SmartAppraisel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.AspNetCore.Authorization;


namespace SmartAppraisel.Controllers
{
    [Authorize(Roles = "1002")]
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
                newAssessmentDetail.IsReviewed = false;
                newAssessmentDetail.Comment = null;
                AssessmentMgmtBL.CreateAssessment(newAssessmentDetail);
                return RedirectToAction("CreateResponse", new { AssessmentID = newAssessmentDetail.AssessmentID, questionID = 1 });
            }

            return View();
        }
        [HttpGet]
        public ActionResult CreateResponse(int AssessmentID, int questionID = 1)
        {
            ViewBag.AssessmentID = AssessmentID;
            ViewBag.QuestionID = questionID;
            ViewBag.Competencies = new SelectList(AssessmentMgmtBL.GetAllCompetencies(), "CompID", "CompName");
            return View();
        }


        public IActionResult CreateAssessmentResponse(AssessmentResponse newAssessmentResponse)
        {
            int pageNo = HttpContext.Session.GetInt32("PageNo") ?? 0;
            pageNo++;

            HttpContext.Session.SetInt32("PageNo", pageNo);
            if (pageNo == 5)
            {
                HttpContext.Session.Remove("PageNo");
                return RedirectToAction("Index");
            }
            else
            {
                if (newAssessmentResponse != null)
                {
                    var model = new AssessmentResponse
                    {
                        AssessmentID = newAssessmentResponse.AssessmentID,
                        Question = newAssessmentResponse.Question,
                        Answer1 = newAssessmentResponse.Answer1,
                        Answer2 = newAssessmentResponse.Answer2,
                        Answer3 = newAssessmentResponse.Answer3,
                        Answer4 = newAssessmentResponse.Answer4,
                        CompetencyIDForQ1 = newAssessmentResponse.CompetencyIDForQ1,
                        CompetencyIDForQ2 = newAssessmentResponse.CompetencyIDForQ2,
                        CompetencyIDForQ3 = newAssessmentResponse.CompetencyIDForQ3,
                        CompetencyIDForQ4 = newAssessmentResponse.CompetencyIDForQ4
                    };
                    AssessmentMgmtBL.CreateAssessmentResponse(model);
                    return RedirectToAction("CreateResponse", new { AssessmentID = model.AssessmentID, questionID = pageNo });
                }
            }

            return View(newAssessmentResponse);
        }
        [HttpGet]
        public ActionResult Review(int AssessmentID)
        {
            
            var Responses = AssessmentMgmtBL.GetAssessmentResponses(AssessmentID);
            var competencyDictionary= AssessmentMgmtBL.GetAllCompetencies().ToDictionary(c => c.CompID, c => c.CompName);
            ViewBag.Competencies = competencyDictionary;
            return View(Responses);
        }
        public ActionResult SubmitReview(int AssessmentID, string Comments)
        {
            AssessmentMgmtBL.ReviewAssessment(AssessmentID, Comments);
            return RedirectToAction("Index");
        }


    }
}