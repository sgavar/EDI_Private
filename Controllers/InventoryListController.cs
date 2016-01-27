using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataInventory.Models;

namespace DataInventory.Controllers
{
    public class InventoryListController : Controller
    {
        //
        // GET: /InventoryList/
        public DataInventoryEntities db = new DataInventoryEntities();

        public ActionResult Index()
        {
            var seriesList = (from p in db.tblProgram 
                          where p.Study_List != null
                          orderby p.Program_Name
                          select new SeriesViewModel
                          {
                              seriesID = p.Program_ID,
                              seriesName = p.Program_Name,
                              studyList = p.Study_List,
                              studyCount = p.Study_Count
                          }).ToList();

            return View("Index", seriesList);
        }

    }
}
