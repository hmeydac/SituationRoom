namespace Lampadas.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/ember").Include(
                "~/Scripts/Libs/handlebars.js",
                "~/Scripts/Libs/ember.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/Libs/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Libs/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/Libs/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Libs/jquery.unobtrusive*",
                        "~/Scripts/Libs/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Libs/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/themes/office17/site.css"));

            RegisterEmber(bundles);
        }

        private static void RegisterEmber(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/proxy").Include("~/Scripts/Services/taskservice.js"));
            bundles.Add(new ScriptBundle("~/bundles/models").Include("~/Scripts/Models/*.model.js"));
            bundles.Add(new ScriptBundle("~/bundles/controllers").Include("~/Scripts/Controllers/*.controller.js"));
            bundles.Add(new ScriptBundle("~/bundles/views").Include("~/Scripts/Views/*.view.js"));
            bundles.Add(new ScriptBundle("~/bundles/routes").Include("~/Scripts/application/routes.js"));
            bundles.Add(new ScriptBundle("~/bundles/application").Include("~/Scripts/application/application.js"));
        }
    }
}