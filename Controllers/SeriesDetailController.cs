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
    public class SeriesDetailController : Controller
    {
        //
        // GET: /SeriesDetail/

        public DataInventoryEntities db = new DataInventoryEntities();

        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult GetSeriesDetail(int seriesID, int studyID)
        {
            var series = (from p in db.tblProgram
                          where p.Program_ID == seriesID
                          select new SeriesViewModel
                          {
                              seriesID = p.Program_ID,
                              seriesName = p.Program_Name,
                              seriesDesc = p.Program_Description,
                              studyList = p.Study_List,
                              investigatorList = p.Steward_List,
                              searchVariables = p.Search_Variables
                          }).ToList();

            return View("Index", series);
        }

        public object model { get; set; }

        private string getVar(string var, string default_var = "")
        {
            return string.IsNullOrWhiteSpace(var) ? default_var : var;
        }

    }
}
