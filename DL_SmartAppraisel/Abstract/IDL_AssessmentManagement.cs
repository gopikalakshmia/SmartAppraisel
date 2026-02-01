using DL_SmartAppraisel.Model;
using SmartAppraisel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DL_SmartAppraisel.Abstract
{
    internal interface IDL_AssessmentManagement
    {
                public string CreateAssessment(AssessmentDetail newAssessmentDetail);
                public string CreateAssessmentResponse(AssessmentResponse newAssessmentResponse);
                public List<AssessmentDetail> GetAllAssessments();
                public List<CompetencyDetail> GetAllCompetencies();
                   public List<AssessmentResponse> GetAssessmentResponses(int AssessmentID);
                    public void ReviewAssessment(int AssessmentID, string Comment);

    }
}
