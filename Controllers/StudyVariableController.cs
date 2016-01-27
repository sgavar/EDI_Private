using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataInventory.Models;

using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Text;

namespace DataInventory.Controllers
{
    public class StudyVariableController : Controller
    {
        //
        // GET: /StudyVariable/

        public DataInventoryEntities db = new DataInventoryEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStudyVariable(int studyID, string searchTerm, string searchType, string studyType, int page, string sortColumn, string sortDirection)
        {
            if (searchTerm == "null")
                searchTerm = "";

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
                                 studyID = f.Study_ID
                             }).ToList();
            }

            List<StudyVariableViewModel> svvmList = new List<StudyVariableViewModel>();

            var totalRows = 0;
            var firstRow = 0;
            var lastRow = 0;
            var lastPage = 0;

            foreach (var item in study)
            {
                StudyVariableViewModel svvm = new StudyVariableViewModel();
                svvm.study = item;

                var variable = db.Database.SqlQuery<VariableViewModel>("EXEC uspSearchVariableDataByStudy {0}, {1}, {2}, {3}, {4}, {5} ", svvm.study.studyID, searchTerm, searchType, page, sortColumn, sortDirection).ToList();

                svvm.variableList = variable;
                svvmList.Add(svvm);

                foreach (var row in variable.ToList())
                {
                    totalRows = row.totalRows;
                    firstRow = row.firstRow;
                    lastRow = row.lastRow;
                    lastPage = row.lastPage;
                }     
            }

            ViewBag.studyID = studyID;
            ViewBag.searchTerm = searchTerm;
            ViewBag.searchType = searchType;
            ViewBag.totalRows = totalRows;
            ViewBag.firstRow = firstRow;
            ViewBag.lastRow = lastRow;
            ViewBag.lastPage = lastPage;

            return PartialView("_StudyVariable", svvmList);
        }

        public ActionResult Export(int hdnStudyID, string[] cbStudyVariable, string cbStudyVarAll, string hdSearchTerm, string hdSearchType)
        {
            var variableList = "";

            for (int i = 0; i < cbStudyVariable.Length; i++)
            {
                variableList = variableList + "; " + cbStudyVariable[i];
            }

            var variable = db.Database.SqlQuery<VariableViewModel>("EXEC uspExportStudyVariable {0}, {1}, {2}, {3}, {4} ", hdnStudyID, variableList, cbStudyVarAll, hdSearchTerm, hdSearchType).ToList();

            StringWriter sw = new StringWriter();

            // Title
            sw.Write("ED Data Inventory Export");
            sw.Write(sw.NewLine);
            sw.Write(sw.NewLine);
            sw.Write("U.S. Department of Education - http://datainventory.ed.gov/");
            sw.Write(sw.NewLine);
            sw.Write(sw.NewLine);

            // Header
            sw.WriteLine("\"Variable Name\",\"Variable Label\",\"Study Name\",\"File Name\",\"Value\"");

            // Data
            foreach (var line in variable.ToList())
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"", line.variableName, line.variableLabel, line.studyName, line.fileList, line.valueList));
            }

            Response.AddHeader("content-disposition", "attachment;filename=DataInventoryExport.csv");
            Response.ContentType = "text/csv";

            Response.Write(sw.ToString());
            Response.End();

            return File(sw.ToString(), Response.ContentType);            
        }
    }
}
