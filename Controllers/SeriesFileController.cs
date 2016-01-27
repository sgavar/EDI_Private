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
    public class SeriesFileController : Controller
    {
        //
        // GET: /SeriesFile/

        public DataInventoryEntities db = new DataInventoryEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSeriesFile(int seriesID)
        {
            var series = (from p in db.tblProgram
                          where p.Program_ID == seriesID
                          select new SeriesViewModel
                          {
                              seriesID = p.Program_ID,
                              seriesName = p.Program_Name
                          }).ToList();

            List<SeriesFileViewModel> svvmList = new List<SeriesFileViewModel>();

            foreach (var item in series)
            {
                SeriesFileViewModel svvm = new SeriesFileViewModel();
                svvm.series = item;

                var file = db.Database.SqlQuery<FileViewModel>("EXEC uspGetSeriesFile {0} ", svvm.series.seriesID).ToList();

                svvm.fileList = file;
                svvmList.Add(svvm);
            }

            return PartialView("_SeriesFile", svvmList);
        }

        public ActionResult Export(Guid fileID, string fileName, int studyID, string studyName)
        {
            var file = db.Database.SqlQuery<VariableViewModel>("EXEC uspExportFileVariable {0}, {1} ", fileID, studyID).ToList();

            StringWriter sw = new StringWriter();

            // Title
            sw.Write("ED Data Inventory Export");
            sw.Write(sw.NewLine);
            sw.Write(sw.NewLine);
            sw.Write("U.S. Department of Education - http://datainventory.ed.gov/");
            sw.Write(sw.NewLine);
            sw.Write(sw.NewLine);

            sw.Write(studyName.Replace("–", "-").Replace(",", ""));
            sw.Write(sw.NewLine);
            sw.Write(fileName + " file");
            sw.Write(sw.NewLine);
            sw.Write(sw.NewLine);

            // Header
            sw.WriteLine("\"Variable Name\",\"Variable Label\",\"Value\"");

            // Data
            foreach (var line in file.ToList())
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\"", line.variableName, line.variableLabel, line.valueList));
            }

            Response.AddHeader("content-disposition", "attachment;filename=DataInventoryExport.csv");
            Response.ContentType = "text/csv";

            Response.Write(sw.ToString());
            Response.End();

            return File(sw.ToString(), Response.ContentType);
        }

    }
}
