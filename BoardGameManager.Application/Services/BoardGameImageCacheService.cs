using BoardGameManager.Domain.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace BoardGameManager.Application.Services
{
    public class BoardGameImageCacheService : BoardGameManager.Application.Services.IBoardGameImageCacheService
    {
        ConcurrentDictionary<string, BoardGameImages> _boardGameImagesCache = new ConcurrentDictionary<string, BoardGameImages>();

        public bool TryGetBoardGameImages(Uri boardGameGeekReviewUrl, out BoardGameImages boardGameImages)
        {

            var cacheKey = boardGameGeekReviewUrl.ToString();

            if (!_boardGameImagesCache.ContainsKey(cacheKey))
            {
                boardGameImages = null;
                return false;
            }

            boardGameImages = _boardGameImagesCache[cacheKey];

            return true;
        }

        public void AddBoardGameImagesToCache(Uri boardGameGeekReviewUri, BoardGameImages boardGameImages)
        {
            _boardGameImagesCache[boardGameGeekReviewUri.ToString()] = boardGameImages;
        }
    }
}
