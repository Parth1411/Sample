namespace MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Script/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/Script/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/DeveloperJs").Include(
                        "~/Content/Script/developer.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/Script/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/Script/bootstrap.js",
                      "~/Content/Script/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/CSS/bootstrap.css",
                      "~/Content/CSS/site.css",
                      "~/Content/CSS/developer.css"));
        }
    }
}