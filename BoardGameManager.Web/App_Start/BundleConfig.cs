using System.Web;
using System.Web.Optimization;
using BoardGameManager.Web.Constants;

namespace BoardGameManager.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle(BundlePaths.JavaScript.JQuery,
                        "//ajax.googleapis.com/ajax/libs/jquery/2.0.3/jquery.min.js")
                        .Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle(BundlePaths.JavaScript.JQueryUi).Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle(BundlePaths.JavaScript.JQueryValidation).Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle(BundlePaths.JavaScript.Modernizer).Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle(BundlePaths.JavaScript.Knockout).Include(
                        "~/Scripts/knockout-*"));

            bundles.Add(new ScriptBundle(BundlePaths.JavaScript.Amplify).Include(
                        "~/Scripts/amplify*"));

            bundles.Add(new ScriptBundle(BundlePaths.JavaScript.NetEyeWaitIndicator).Include(
                        "~/Scripts/jquery.activity-indicator-{version}.js"));

            bundles.Add(new ScriptBundle(BundlePaths.JavaScript.Underscore).Include(
                        "~/Scripts/underscore*"));

            bundles.Add(new ScriptBundle(BundlePaths.JavaScript.CustomAppModules).Include(
                        "~/Scripts/app/model.boardgame.js",
                        "~/Scripts/app/dataservice.boardgames.js",
                        "~/Scripts/app/modelmapper.js",
                        "~/Scripts/app/viewmodel.boardgames.js",
                        "~/Scripts/app/datacontext.js",
                        "~/Scripts/app/binder.js",
                        "~/Scripts/app/bootstrapper.js"));

            bundles.Add(new ScriptBundle(BundlePaths.JavaScript.Main).Include(
                        "~/Scripts/main.js"));

            bundles.Add(new StyleBundle(BundlePaths.Css.JQueryUi).Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle(BundlePaths.Css.Normalize).Include(
                "~/Content/normalize.css"));

            bundles.Add(new StyleBundle(BundlePaths.Css.Main).Include(
                "~/Content/main.css"));
        }
    }
}