using DL_SmartAppraisel.Model;
using SmartAppraisel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL_SmartAppraisel.Repository
{
    public class DL_AssessmentManagement
    {
        SmartAppraiselDbContext db = new SmartAppraiselDbContext();

        public string CreateAssessment(AssessmentDetail newAssessmentDetail)
        {
            if (newAssessmentDetail != null)
            {
                db.AssessmentDetails.Add(newAssessmentDetail);
                db.SaveChanges();
                return "created";
            }
            return "not created";
        }
        public string CreateAssessmentResponse(AssessmentResponse newAssessmentResponse)
        {
            if (newAssessmentResponse != null)
            {
                db.AssessmentResponses.Add(newAssessmentResponse);
                db.SaveChanges();
                return "created";
            }
            return "not created";
        }
        public List<AssessmentDetail> GetAllAssessments()
        {
            return db.AssessmentDetails.ToList();
        }
        public List<CompetencyDetail> GetAllCompetencies()
        {
            return db.CompetencyDetails.ToList();
        }
        public List<AssessmentResponse> GetAssessmentResponses(int AssessmentID)
        {
            return db.AssessmentResponses.Where(r => r.AssessmentID == AssessmentID).ToList();
        }
        public void ReviewAssessment(int AssessmentID, string Comment)
        {
            var assessment = db.AssessmentDetails.FirstOrDefault(a => a.AssessmentID == AssessmentID);
            if (assessment != null)
            {
                assessment.IsReviewed = true;
                assessment.Comment = Comment;
                db.SaveChanges();   
            }
                
            }
    }
}