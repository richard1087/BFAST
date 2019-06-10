using System.Web;
using System.Web.Optimization;

namespace JGC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // JGC CSS
            bundles.Add(new StyleBundle("~/Content/JGCcss").Include(
                    "~/Content/res/vendors/bootstrap/dist/css/bootstrap.min.css",
                    "~/Content/res/vendors/font-awesome/css/font-awesome.min.css",
                    "~/Content/res/vendors/nprogress/nprogress.css",
                    "~/Content/res/vendors/iCheck/skins/flat/green.css",
                    "~/Content/res/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
                    "~/Content/res/vendors/jqvmap/dist/jqvmap.min.css",
                    "~/Content/res/vendors/bootstrap-daterangepicker/daterangepicker.css",
                    "~/Content/res/vendors/datatables.net-bs/css/dataTables.bootstrap.min.css",
                    "~/Content/res/build/css/custom.min.css",
                    "~/Content/res/build/css/select2.min.css",
                    "~/Content/res/build/css/jgc-style.css"));

            // JGC JS
            bundles.Add(new ScriptBundle("~/Content/JGCjs").Include(
                    "~/Content/res/vendors/jquery/dist/jquery.min.js",
                    "~/Content/res/build/js/jquery-3.2.1.min.js",
                    "~/Content/res/vendors/bootstrap/dist/js/bootstrap.min.js",
                    "~/Content/res/vendors/fastclick/lib/fastclick.js",
                    "~/Content/res/vendors/nprogress/nprogress.js",
                    "~/Content/res/vendors/Chart.js/dist/Chart.min.js",
                    "~/Content/res/vendors/gauge.js/dist/gauge.min.js",
                    "~/Content/res/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
                    "~/Content/res/vendors/iCheck/icheck.min.js",
                    "~/Content/res/vendors/skycons/skycons.js",
                    "~/Content/res/vendors/Flot/jquery.flot.js",
                    "~/Content/res/vendors/Flot/jquery.flot.pie.js",
                    "~/Content/res/vendors/Flot/jquery.flot.time.js",
                    "~/Content/res/vendors/Flot/jquery.flot.stack.js",
                    "~/Content/res/vendors/Flot/jquery.flot.resize.js",
                    "~/Content/res/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
                    "~/Content/res/vendors/flot-spline/js/jquery.flot.spline.min.js",
                    "~/Content/res/vendors/flot.curvedlines/curvedLines.js",
                    "~/Content/res/vendors/DateJS/build/date.js",
                    "~/Content/res/vendors/jqvmap/dist/jquery.vmap.js",
                    "~/Content/res/vendors/jqvmap/dist/maps/jquery.vmap.world.js",
                    "~/Content/res/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
                    "~/Content/res/vendors/moment/min/moment.min.js",
                    "~/Content/res/vendors/bootstrap-daterangepicker/daterangepicker.js",
                    "~/Content/res/vendors/datatables.net/js/jquery.dataTables.min.js",
                    "~/Content/res/vendors/datatables.net-bs/js/dataTables.bootstrap.min.js",
                    "~/Content/res/build/js/select2.min.js",
                    "~/Content/res/build/js/custom.js"));
            bundles.Add(new ScriptBundle("~/Content/CommonJS").Include(
                      "~/js/Common.js",
                      "~/js/GetInput.js",
                      "~/js/Required.js",
                      "~/js/KeyPressText.js",
                      "~/js/DatatablesGrid.js",
                      "~/js/InUpDel.js"));
        }
    }
}
