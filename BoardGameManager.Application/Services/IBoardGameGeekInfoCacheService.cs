using BoardGameManager.Domain.Services;
using System;

namespace BoardGameManager.Application.Services
{
    public interface IBoardGameGeekInfoCacheService
    {
        bool TryGetBoardGameImages(Uri boardGameGeekReviewUrl, out BoardGameGeekGameDetails boardGameGeekGameDetails);
        void AddBoardGameImagesToCache(Uri boardGameGeekReviewUri, BoardGameGeekGameDetails boardGameGeekGameDetails);
    }
}
