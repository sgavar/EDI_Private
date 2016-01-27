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
    public class StudyDetailController : Controller
    {
        //
        // GET: /StudyDetail/

        public DataInventoryEntities db = new DataInventoryEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetStudyDetail(int seriesID, int studyID, string studyType)
        {
            var study = db.Database.SqlQuery<StudyViewModel>("EXEC uspGetStudyDetail {0}, {1} ", studyID, studyType).ToList();

            ViewBag.seriesID = seriesID;
            ViewBag.studyID = studyID;
            ViewBag.studyType = studyType;

            return View("_StudyDetail", study);
        }

        public object model { get; set; }

    }
}
