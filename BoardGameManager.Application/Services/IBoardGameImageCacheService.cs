using BoardGameManager.Domain.Services;
using System;

namespace BoardGameManager.Application.Services
{
    public interface IBoardGameImageCacheService
    {
        bool TryGetBoardGameImages(Uri boardGameGeekReviewUrl, out BoardGameImages boardGameImages);
        void AddBoardGameImagesToCache(Uri boardGameGeekReviewUri, BoardGameImages boardGameImages);
    }
}
