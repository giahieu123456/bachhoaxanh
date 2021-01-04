using System.Web;
using System.Web.Optimization;

namespace bachhoaxanhdemo
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Utility/jquery-{version}.js"
                        , "~/Scripts/Home/dropdownHeader.js",
                        "~/Scripts/Home/scrollbacktop.js",
                        "~/Scripts/Home/popupfeedback.js",
                         "~/Scripts/Home/LoadMore.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Utility/jquery.validate*"));

            //Bundles Owl Carousel
            bundles.Add(new ScriptBundle("~/bundles/owl.carousel").Include(
                        "~/Scripts/Home/owl.carousel.min.js",
                        "~/Scripts/Home/owlcarousel.js"
                        
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/owl.carousel").Include(
            //          "~/Content/css/owl.carousel.min.css",
            //          "~/Content/css/owl.theme.default.min.css"
            //          ));

            bundles.Add(new StyleBundle("~/Content/homecss").Include(
                      "~/Content/css/minireset.min.css",
                      "~/Content/css/owl.carousel.min.css",
                      "~/Content/css/owl.theme.default.min.css",
                      "~/Content/css/header.css",
                      "~/Content/css/section.css",
                      "~/Content/css/slidebanner.css",
                      "~/Content/css/groupcate.css",
                      "~/Content/css/groupfeaturefresh.css",
                      "~/Content/css/groupfeatureproduct.css",
                      "~/Content/css/footer.css"
                     ));
        }
    }
}
