using System.Web;
using System.Web.Optimization;

namespace DataInventory
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Scripts/jquery").Include( 
                "~/Scripts/jquery-1.7.1.js",
                "~/Scripts/jquery-ui-1.10.3.custom.js",
                "~/Scripts/jquery-ui.custom.js",
                "~/Scripts/DataInventory.js",
                "~/Scripts/Home.js",
                "~/Scripts/jquery.tablesorter.js",
                "~/Scripts/jquery.tablesorter.pager.js",
                "~/Scripts/jquery.easing.min.js",
                "~/Scripts/slides.min.jquery.js"));

             bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/diMain.css",
                "~/Content/jquery-ui-1.10.3.custom.css"));
        }
    }
}