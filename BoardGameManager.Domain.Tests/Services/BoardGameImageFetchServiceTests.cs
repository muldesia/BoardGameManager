using BoardGameManager.Domain.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager.Domain.Tests.Services
{
    [TestFixture]
    public class BoardGameImageFetchServiceTests
    {
        [TestFixture]
        public class GetBoardGameImage
        {
            [Test]
            public void Get_Image_Successfully()
            {
                //Arrange
                var boardGameImageFetchService = new BoardGameImageFetchService();
                var boardGameGeekReviewUrl = new Uri("http://boardgamegeek.com/boardgame/6472");

                //Act
                var imageUrls = boardGameImageFetchService.GetBoardGameImages(boardGameGeekReviewUrl);

                //Assert

            }
        }
    }
}
