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
    public class SeriesVariableController : Controller
    {
        //
        // GET: /SeriesVariable/

        public DataInventoryEntities db = new DataInventoryEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSeriesVariable(int seriesID, string searchTerm, string searchType, int page, string sortColumn, string sortDirection)
        {
            if (searchTerm == "null")
                searchTerm = "";

            var series = (from p in db.tblProgram
                             where p.Program_ID == seriesID
                             select new SeriesViewModel
                             {
                                 seriesID = p.Program_ID,
                                 seriesName = p.Program_Name
                             }).ToList();

            List<SeriesVariableViewModel> svvmList = new List<SeriesVariableViewModel>();

            var totalRows = 0;
            var firstRow = 0;
            var lastRow = 0;
            var lastPage = 0;

            foreach (var item in series)
            {
                SeriesVariableViewModel svvm = new SeriesVariableViewModel();
                svvm.series = item;

                var variable = db.Database.SqlQuery<VariableViewModel>("EXEC uspSearchVariableDataBySeries {0}, {1}, {2}, {3}, {4}, {5} ", svvm.series.seriesID, searchTerm, searchType, page, sortColumn, sortDirection).ToList();

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

            ViewBag.seriesID = seriesID;
            ViewBag.searchTerm = searchTerm;
            ViewBag.searchType = searchType;
            ViewBag.totalRows = totalRows;
            ViewBag.firstRow = firstRow;
            ViewBag.lastRow = lastRow;
            ViewBag.lastPage = lastPage;

            return PartialView("_SeriesVariable", svvmList);
        }

        public ActionResult Export(string[] cbSeriesVariable, string submit, string cbSeriesVarAll, int hdSeriesID, string hdSearchTerm, string hdSearchType)
        {
            var variableList = "";

            if (cbSeriesVarAll == "on")
            {
                variableList = "";
            }
            else 
            {
                for (int i = 0; i < cbSeriesVariable.Length; i++)
                {
                    variableList = variableList + "; " + cbSeriesVariable[i];
                }
            }

            var variable = db.Database.SqlQuery<VariableViewModel>("EXEC uspExportSeriesVariable {0}, {1}, {2}, {3}, {4} ", variableList, cbSeriesVarAll, hdSeriesID, hdSearchTerm, hdSearchType).ToList();

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
