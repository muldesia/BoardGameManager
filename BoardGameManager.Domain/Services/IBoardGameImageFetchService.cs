using System;

namespace BoardGameManager.Domain.Services
{
    public interface IBoardGameImageFetchService
    {
        BoardGameImages GetBoardGameImages(Uri boardGameGeekReviewUrl);
    }
}
