using System;

namespace BoardGameManager.Domain.Services
{
    public interface IBoardGameGeekInfoService
    {
        BoardGameGeekGameDetails GetBoardGameDetails(Uri boardGameGeekReviewUrl);
    }
}
