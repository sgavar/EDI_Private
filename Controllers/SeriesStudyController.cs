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
    public class SeriesStudyController : Controller
    {
        //
        // GET: /SeriesStudy/

        public DataInventoryEntities db = new DataInventoryEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSeriesStudy(int seriesID)
        {
            var studyList = (from p in db.tblProgram
                          where p.Program_ID == seriesID
                          select new SeriesStudyViewModel
                          {
                              studyList = p.Study_List
                          }).ToList();

            return PartialView("_SeriesStudy", studyList);
        }
    }
}
