using System.Web;
using System.Web.Optimization;

namespace Eticarett
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

            ////bundles.Add(new StyleBundle("~/admin/styles").
            ////   Include("~/content/styles/admin.css").
            ////   Include("~/content/styles/animate.css").
            ////   Include("~/content/styles/bootstrap-theme.css").
            ////   Include("~/content/styles/bootstrap-theme.min.css").
            ////   Include("~/content/styles/bootstrap.min.css").
            ////   Include("~/content/styles/font-awesome.min.css").
            ////   Include("~/content/styles/main.css").
            ////   Include("~/content/styles/prettyPhoto.css").
            ////   Include("~/content/styles/price-range.css").
            ////   Include("~/content/styles/responsive.css").
            ////   Include("~/content/styles/Site").
            ////   Include("~/content/styles/bootstrap.css"));

            ////bundles.Add(new ScriptBundle("~/admin/scripts").
            ////   //Include("~/content/scripts/_references.js").
            ////   Include("~/content/scripts/bootstrap.js").
            ////   Include("~/content/scripts/bootstrap.min.js").
            ////   Include("~/content/scripts/contact.js").
            ////   Include("~/content/scripts/Form.js").
            ////   Include("~/content/scripts/gmaps.js").
            ////   Include("~/content/scripts/html5shiv.js").
            ////   Include("~/content/scripts/jquery-1.10.2.intellisense.js").
            ////   Include("~/content/scripts/jquery-1.10.2.js").
            ////   Include("~/content/scripts/jquery-1.10.2.min.js").
            ////   //Include("~/content/scripts/jquery-1.11.2.js").
            ////   Include("~/content/scripts/jquery.js").
            ////   Include("~/content/scripts/jquery.prettyPhoto.js").
            ////   Include("~/content/scripts/jquery.scrollUp.min.js").
            ////   Include("~/content/scripts/jquery.validate-vsdoc.js").
            ////   Include("~/content/scripts/jquery.validate.js").
            ////   Include("~/content/scripts/jquery.validate.min.js").
            ////   Include("~/content/scripts/jquery.validate.unobtrusive.js").
            ////   Include("~/content/scripts/jquery.validate.unobtrusive.min.js").
            ////   Include("~/content/scripts/main.js").
            ////   Include("~/content/scripts/modernizr-2.6.2.js").
            ////   Include("~/content/scripts/price-range.js").
            ////   Include("~/content/scripts/respond.js").
            ////   Include("~/content/scripts/respond.min.js"));


            //bundles.Add(new StyleBundle("~/styles").
            //   //Include("~/content/styles/admin.css").
            //   Include("~/content/styles/animate.css").
            //   //Include("~/content/styles/bootstrap-theme.css").
            //   //Include("~/content/styles/bootstrap-theme.min.css").
            //   Include("~/content/styles/bootstrap.min.css").
            //   Include("~/content/styles/font-awesome.min.css").
            //   Include("~/content/styles/main.css").
            //   Include("~/content/styles/prettyPhoto.css").
            //   Include("~/content/styles/price-range.css").
            //   Include("~/content/styles/responsive.css")
            //   //Include("~/content/styles/Site")
            //   //Include("~/content/styles/bootstrap.css")
            //   );

            //bundles.Add(new ScriptBundle("~/scripts").
            //   //Include("~/content/scripts/_references.js").
            //   Include("~/content/scripts/bootstrap.js").
            //   Include("~/content/scripts/bootstrap.min.js").
            //   Include("~/content/scripts/contact.js").
            //   //Include("~/content/scripts/Form.js").
            //   Include("~/content/scripts/gmaps.js").
            //   Include("~/content/scripts/html5shiv.js").
            //   //Include("~/content/scripts/jquery-1.10.2.intellisense.js").
            //   //Include("~/content/scripts/jquery-1.10.2.js").
            //   //Include("~/content/scripts/jquery-1.10.2.min.js").
            //   //Include("~/content/scripts/jquery-1.11.2.js").
            //   Include("~/content/scripts/jquery.js").
            //   Include("~/content/scripts/jquery.prettyPhoto.js").
            //   Include("~/content/scripts/jquery.scrollUp.min.js").
            //   //Include("~/content/scripts/jquery.validate-vsdoc.js").
            //   //Include("~/content/scripts/jquery.validate.js").
            //   //Include("~/content/scripts/jquery.validate.min.js").
            //   //Include("~/content/scripts/jquery.validate.unobtrusive.js").
            //   //Include("~/content/scripts/jquery.validate.unobtrusive.min.js").
            //   Include("~/content/scripts/main.js").
            //   //Include("~/content/scripts/modernizr-2.6.2.js").
            //   Include("~/content/scripts/price-range.js")
            //  //Include("~/content/scripts/respond.js").
            //  /* Include("~/content/scripts/respond.min.js")*/);
        }
    }
}
