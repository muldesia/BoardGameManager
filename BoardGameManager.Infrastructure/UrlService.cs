using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BoardGameManager.Infrastructure
{
    public static class UrlService
    {
        public static IEnumerable<string> GetRelativeVirtualPathsForAllItemsInVirtualFolder(string virtualFolderPath)
        {
            var physicalPath = HttpContext.Current.Server.MapPath(virtualFolderPath);
            var absolutePaths = Directory.GetFiles(physicalPath, "*.*", SearchOption.AllDirectories);


            return absolutePaths.Select(
                x => VirtualPathUtility.ToAbsolute(virtualFolderPath + x.Replace(physicalPath, "")));
        }
    }
}
