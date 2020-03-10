using System.Web;
using System.Web.Optimization;

namespace EventPlanner
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/eventjs").Include(
                    "~/Scripts/js/jquery.js",
                    "~/Scripts/js/masonry.pkgd.min.js",
                    "~/Scripts/js/jquery.collapsible.min.js",
                    "~/Scripts/js/swiper.min.js",
                    "~/Scripts/js/jquery.countdown.min.js",
                    "~/Scripts/js/circle-progress.min.js",
                    "~/Scripts/js/jquery.countTo.min.js",
                    "~/Scripts/js/custom.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/adminjs").Include(
                    "~/Scripts/admin/jquery.min.js",
                    "~/Scripts/admin/bootstrap.bundle.min.js",
                    "~/Scripts/admin/adminlte.min.js",                    
                    "~/Scripts/admin/demo.js"                    
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/eventcss").Include(
                    "~/Content/css/bootstrap.min.css",
                    "~/Content/css/font-awesome.min.css",
                    "~/Content/css/swiper.min.css",
                    "~/Content/css/style.css"
                ));
            bundles.Add(new StyleBundle("~/Content/admincss").Include(
                    "~/Content/admin/all.min.css",
                    "~/Content/admin/ionicons.min.css",
                    "~/Content/admin/adminlte.min.css"
                ));
        }
    }
}
