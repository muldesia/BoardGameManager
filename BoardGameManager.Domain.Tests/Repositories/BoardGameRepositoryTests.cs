using System.Linq;
using BoardGameManager.Domain.Repositories;
using BoardGameManager.EntityFramework;
using BoardGameManater.EntityFramework.Tests.Fakes;
using Castle.Core.Internal;
using FizzWare.NBuilder;
using FluentAssertions;
using NUnit.Framework;
using BoardGame = BoardGameManager.EntityFramework.Entities.BoardGame;
using AutoMapper;
using BoardGameManager.Domain.MapperProfiles;

namespace BoardGameManager.Domain.Tests.Repositories
{
    [TestFixture]
    public class BoardGameRepositoryTests
    {
        [TestFixture]
        public class ListAll
        {
            [TestFixtureSetUp]
            public void SetFixtureSetUp()
            {
                Mapper.Initialize(x =>
                {
                    x.AddProfile<EntityFrameworkToDomainProfile>();
                });

            }

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
                var boardGameList = Builder<BoardGame>.CreateListOfSize(2).Build();
                boardGameList[1].GameType = EntityFramework.Enums.GameType.Expansion;
                foreach (var boardGame in boardGameList)
                {
                    fakeDbContext.BoardGames.Add(boardGame);
                }

                var unitOfWork = new UnitOfWork<BoardGameFakeDbContext>(fakeDbContext);
                var boardGameRepository = new BoardGameRepository(unitOfWork);

                //Act
                var boardGamesListed = boardGameRepository.ListAll();

                //Assert
                boardGamesListed.Should().HaveCount(2);
                boardGamesListed.ElementAt(0).ShouldHave().AllPropertiesBut(x => x.GameType).EqualTo(fakeDbContext.BoardGames.ElementAt(0));
                boardGamesListed.ElementAt(1).ShouldHave().AllPropertiesBut(x => x.GameType).EqualTo(fakeDbContext.BoardGames.ElementAt(1));
                boardGamesListed.ElementAt(1).GameType.ShouldBeEquivalentTo<GameType>(GameType.Expansion);
            }
        }
    }
}
