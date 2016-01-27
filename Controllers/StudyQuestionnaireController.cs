using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataInventory.Models;

namespace DataInventory.Controllers
{
    public class StudyQuestionnaireController : Controller
    {
        //
        // GET: /StudyQuestionnaire/

        public DataInventoryEntities db = new DataInventoryEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStudyQuestionnaire(int studyID, string studyType)
        {
            var study = new List<StudyViewModel>();

            if (studyType == "study")
            {
                study = (from s in db.tblStudy
                         where s.Study_ID == studyID
                         select new StudyViewModel
                         {
                             studyID = s.Study_ID
                         }).ToList();
            }
            else
            {
                study = (from f in db.tblFollow_Up
                         where f.Follow_Up_ID == studyID
                         select new StudyViewModel
                         {
                             studyID = f.Follow_Up_ID
                         }).ToList();
            }

            List<StudyQuestionnaireViewModel> sqvm = new List<StudyQuestionnaireViewModel>();

            foreach (var item in study)
            {
                StudyQuestionnaireViewModel svvm = new StudyQuestionnaireViewModel();
                svvm.study = item;

                var questionnaire = db.Database.SqlQuery<QuestionnaireViewModel>("EXEC uspGetStudyQuestionnaire {0}, {1} ", svvm.study.studyID, studyType).ToList();

                svvm.questionnaireList = questionnaire;
                sqvm.Add(svvm);
            }

            return PartialView("_StudyQuestionnaire", sqvm);
        }

    }
}
