using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Helpers;
using System.Web.Mvc;
using BoardGameManager.Domain.Repositories;
using BoardGameManager.Web.ViewModels;
using BoardGameManager.Infrastructure.ActionResults;
using System.Collections.Generic;
using BoardGameManager.Infrastructure;
using BoardGameManager.Web.Constants;
using System.Diagnostics;
using System.Web.Optimization;

namespace BoardGameManager.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manifest()
        {
            var inDebugMode = false;
            SetDebugModeVariable(ref inDebugMode);

            List<string> scriptsPaths = new List<string>();
            List<string> contentPaths = new List<string>();
            if (inDebugMode)
            {
                scriptsPaths.AddRange(UrlService.GetRelativeVirtualPathsForAllItemsInVirtualFolder("~/Scripts/"));
                contentPaths.AddRange(UrlService.GetRelativeVirtualPathsForAllItemsInVirtualFolder("~/Content/"));
            }
            else
            {
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.JQueryValidation));
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.Modernizer));
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.Knockout));
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.JQuery));
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.JQueryUi));
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.Amplify));
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.NetEyeWaitIndicator));
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.Underscore));
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.NetEyeWaitIndicator));
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.JQueryMouseWheel));
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.JQueryJScrollPane));
                scriptsPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.JavaScript.CustomAppModules));

                contentPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.Css.Normalize));
                contentPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.Css.JQueryUi));
                contentPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.Css.JQueryJScrollPane));
                contentPaths.Add(BundleTable.Bundles.ResolveBundleUrl(BundlePaths.Css.Main));
            }
            
            var cacheResources = new List<string>();
            cacheResources.AddRange(contentPaths);
            cacheResources.AddRange(scriptsPaths);

            var manifestResult = new ManifestResult("1.1")
            {
                CacheResources = cacheResources,
                NetworkResources = new string[] { "*" }
            };

            return manifestResult;
        }

        [Conditional("DEBUG")]
        private void SetDebugModeVariable(ref bool inDebugMode)
        {
            inDebugMode = true;
        }
    }
}
