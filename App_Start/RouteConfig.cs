using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DataInventory
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Search",
                "Search",
                new { controller = "Search", action = "Index"},
                new string[] { "DataInventory.Controllers" }
            );

            routes.MapRoute(
                "SearchResults",
                "Search/{searchTerm}/{searchType}",
                new { controller = "Search", action = "SearchData", searchTerm = UrlParameter.Optional, searchType = UrlParameter.Optional },
                new string[] { "DataInventory.Controllers" }
            );

            routes.MapRoute(
                "Detail",
                "Detail/{seriesID}/{studyID}/{studyType}",
                new { controller = "Detail", action = "Index", seriesID = UrlParameter.Optional, studyID = UrlParameter.Optional, studyType = UrlParameter.Optional },
                new string[] { "DataInventory.Controllers" }
            );

            routes.MapRoute(
                "SeriesDetail",
                "SeriesDetail/{seriesID}/{studyID}",
                new { controller = "SeriesDetail", action = "GetSeriesDetail", seriesID = UrlParameter.Optional, studyID = UrlParameter.Optional },
                new string[] { "DataInventory.Controllers" }
            );           

            routes.MapRoute(
                "StudyDetail",
                "StudyDetail/{seriesID}/{studyID}/{studyType}",
                new { controller = "StudyDetail", action = "GetStudyDetail", seriesID = UrlParameter.Optional, studyID = UrlParameter.Optional, studyType = UrlParameter.Optional },
                new string[] { "DataInventory.Controllers" }
            );

            routes.MapRoute(
               "GetSeriesVariable",
               "SeriesVariable/GetSeriesVariable/{seriesID}/{searchTerm}/{searchType}/{page}/{sortColumn}/{sortDirection}",
               new { controller = "SeriesVariable", action = "GetSeriesVariable", seriesID = UrlParameter.Optional, searchTerm = UrlParameter.Optional, searchType = UrlParameter.Optional, page = UrlParameter.Optional, sortColumn = UrlParameter.Optional, sortDirection = UrlParameter.Optional },
               new string[] { "DataInventory.Controllers" }
            );

            routes.MapRoute(
               "GetStudyVariable",
               "StudyVariable/GetStudyVariable/{studyID}/{searchTerm}/{searchType}/{studyType}/{page}/{sortColumn}/{sortDirection}",
               new { controller = "StudyVariable", action = "GetStudyVariable", studyID = UrlParameter.Optional, searchTerm = UrlParameter.Optional, searchType = UrlParameter.Optional, studyType = UrlParameter.Optional, page = UrlParameter.Optional, sortColumn = UrlParameter.Optional, sortDirection = UrlParameter.Optional },
               new string[] { "DataInventory.Controllers" }
            );

            routes.MapRoute(
               "FileVarExport",
               "StudyFile/Export/",
               new { controller = "StudyFile", action = "Export", fileID = UrlParameter.Optional },
               new string[] { "DataInventory.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}