using Microsoft.SqlServer.Server;

namespace BoardGameManager.Web.Constants
{
    public static class BundlePaths
    {
        public static class JavaScript
        {
            public const string JQuery = "~/bundles/jquery";
            public const string JQueryUi = "~/bundles/jqueryui";
            public const string JQueryValidation = "~/bundles/jqueryval";
            public const string Modernizer = "~/bundles/modernizr";
            public const string Knockout = "~/bundles/knockout";
            public const string Amplify = "~/bundles/amplify";
            public const string CustomAppModules = "~/bundles/app";
            public const string Main = "~/bundles/main";
            public const string NetEyeWaitIndicator = "~/bundles/neteye";
            public const string Underscore = "~/bundles/bundles/underscore";
            public const string JQueryJScrollPane = "~/bundles/bundles/jqueryjscrollpane";
            public const string JQueryMouseWheel = "~/bundles/bundles/jquerymousewheel";
        }

        public static class Css
        {
            public const string JQueryUi = "~/Content/themes/base/css";
            public const string Normalize = "~/Content/normalize";
            public const string JQueryJScrollPane = "~/Content/jqueryjscrollpane";
            public const string Main = "~/Content/main.css";
        }
    }
}
