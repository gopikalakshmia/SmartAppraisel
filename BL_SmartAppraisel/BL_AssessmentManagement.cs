using DL_SmartAppraisel.Model;
using DL_SmartAppraisel.Repository;
using SmartAppraisel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL_SmartAppraisel
{
    public class BL_AssessmentManagement
    {
        DL_AssessmentManagement repo = new DL_AssessmentManagement();

        public string CreateAssessment(AssessmentDetail newAssessmentDetail)
        {
            return repo.CreateAssessment(newAssessmentDetail);
        }
        public string CreateAssessmentResponse(AssessmentResponse newAssessmentResponse){
            return repo.CreateAssessmentResponse(newAssessmentResponse);
        }
        public List<AssessmentDetail> GetAllAssessments()
        {
            return repo.GetAllAssessments();
        }
        public List<CompetencyDetail> GetAllCompetencies()
        {
            return repo.GetAllCompetencies();
        }
       

    }
}