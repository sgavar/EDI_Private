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
    public class DetailController : Controller
    {
        public DataInventoryEntities db = new DataInventoryEntities();

        public ActionResult Index(int seriesID, int studyID, string studyType)
        {
            ViewBag.seriesID = seriesID;
            ViewBag.studyID = studyID;
            ViewBag.studyType = studyType;

            return View();
        }
    }
}
