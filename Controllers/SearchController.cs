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
    public class SearchController : Controller
    {
        public DataInventoryEntities db = new DataInventoryEntities();

        public ActionResult Index(string txtMenuSearchTerm)
        {
            ViewBag.seriesID = getVar(Request.QueryString["seriesID"]);
            ViewBag.studyID = getVar(Request.QueryString["studyID"]);
            ViewBag.searchType = getVar(Request.QueryString["rdSearchType"], "And");
            ViewBag.studyType = getVar(Request.QueryString["studyType"]);
            ViewBag.showAdvanced = false;
            ViewBag.showHelp = false;
            txtMenuSearchTerm = getVar(txtMenuSearchTerm);
            string txtSearchTerm = getVar(Request.QueryString["txtSearchTerm"]);
            ViewBag.searchTerm = string.IsNullOrWhiteSpace(txtMenuSearchTerm) ? txtSearchTerm : txtMenuSearchTerm;
            if (string.IsNullOrWhiteSpace(ViewBag.seriesID) && string.IsNullOrWhiteSpace(ViewBag.studyID))
            {
                if (string.IsNullOrWhiteSpace(ViewBag.searchTerm) || !string.IsNullOrWhiteSpace(txtSearchTerm))
                {
                    ViewBag.showAdvanced = true;
                    if (Request.QueryString.Count != 0 && string.IsNullOrWhiteSpace(ViewBag.searchTerm))
                    {
                        ViewBag.showHelp = true;
                    }
                }
            }
            return View();
        }

        public ActionResult SearchData(string searchTerm, string searchType)
        {
            var seriesList = db.Database.SqlQuery<SeriesViewModel>("EXEC uspSearchDataBySeries {0}, {1} ", searchTerm, searchType).ToList<SeriesViewModel>();

            List<SearchSeriesStudyViewModel> svvmList = new List<SearchSeriesStudyViewModel>();

            foreach (SeriesViewModel svm in seriesList)
            {
                SearchSeriesStudyViewModel svvm = new SearchSeriesStudyViewModel();
                svvm.series = svm;

                var study = db.Database.SqlQuery<SearchStudyViewModel>("EXEC uspSearchDataByStudy {0}, {1}, {2} ", svvm.series.seriesID, searchTerm, searchType).ToList();

                svvm.studyList = study;
                svvmList.Add(svvm);
            }
            //svvmList = svvmList.OrderByDescending(x => x.studyList.Count()).ToList();
            ViewBag.searchTerm = searchTerm;
            ViewBag.searchType = searchType;

            return PartialView("_DataSearchResults", svvmList);
        }

        private string getVar(string var, string default_var = "")
        {
            return string.IsNullOrWhiteSpace(var) ? default_var : var;
        }
    }
}
