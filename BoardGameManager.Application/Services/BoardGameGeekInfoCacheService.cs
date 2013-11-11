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
    public class BoardGameGeekInfoCacheService : BoardGameManager.Application.Services.IBoardGameGeekInfoCacheService
    {
        ConcurrentDictionary<string, BoardGameGeekGameDetails> _boardGameGeekGameDetailsCache = new ConcurrentDictionary<string, BoardGameGeekGameDetails>();

        public bool TryGetBoardGameImages(Uri boardGameGeekReviewUrl, out BoardGameGeekGameDetails boardGameGeekGameDetails)
        {

            var cacheKey = boardGameGeekReviewUrl.ToString();

            if (!_boardGameGeekGameDetailsCache.ContainsKey(cacheKey))
            {
                boardGameGeekGameDetails = null;
                return false;
            }

            boardGameGeekGameDetails = _boardGameGeekGameDetailsCache[cacheKey];

            return true;
        }

        public void AddBoardGameImagesToCache(Uri boardGameGeekReviewUri, BoardGameGeekGameDetails boardGameGeekGameDetails)
        {
            _boardGameGeekGameDetailsCache[boardGameGeekReviewUri.ToString()] = boardGameGeekGameDetails;
        }
    }
}
