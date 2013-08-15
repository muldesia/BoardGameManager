using System.Linq;
using BoardGameManager.Domain.Repositories;
using BoardGameManager.EntityFramework;
using BoardGameManater.EntityFramework.Tests.Fakes;
using Castle.Core.Internal;
using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;
using BoardGame = BoardGameManager.EntityFramework.Entities.BoardGame;

namespace BoardGameManager.Domain.Tests.Repositories
{
    [TestFixture]
    public class BoardGameRepositoryTests
    {
        
        [TestFixture]
        public class ListAll
        {
            [Test]
            public void Returns_Empty_List_When_No_Board_Games_In_Db()
            {
                //Arrange
                var fakeDbContext = new BoardGameFakeDbContext();
                var unitOfWork = new UnitOfWork<BoardGameFakeDbContext>(fakeDbContext);
                var boardGameRepository = new BoardGameRepository(unitOfWork);

                //Act
                var boardGamesListed = boardGameRepository.ListAll();

                //Assert
                boardGamesListed.Should().BeEmpty();
            }

            [Test]
            public void Returns_All_Games_When_Many_Games_In_Db()
            {
                //Arrange
                var fakeDbContext = new BoardGameFakeDbContext();
                Builder<BoardGame>.CreateListOfSize(2).Build().ForEach(x => fakeDbContext.BoardGames.Add(x));

                var unitOfWork = new UnitOfWork<BoardGameFakeDbContext>(fakeDbContext);
                var boardGameRepository = new BoardGameRepository(unitOfWork);

                //Act
                var boardGamesListed = boardGameRepository.ListAll();

                //Assert
                boardGamesListed.Should().HaveCount(2);
                boardGamesListed.ElementAt(0).ShouldHave().AllProperties().EqualTo(fakeDbContext.BoardGames.ElementAt(0));
                boardGamesListed.ElementAt(1).ShouldHave().AllProperties().EqualTo(fakeDbContext.BoardGames.ElementAt(1));
            }
        }
    }
}
