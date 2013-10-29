using BoardGameManager.EntityFramework.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using BoardGameManager.EntityFramework.Enums;

namespace BoardGameManater.EntityFramework.Tests.Entities
{
    [TestFixture]
    public class BoardGameTests
    {
        [TestFixture]
        public class Constructor
        {
            [Test]
            public void Can_Construct_Entity()
            {
                //Arrange
                var boardGameName = "Game Name";
                var boardGameGeekId = 1;
                var gameType = GameType.Expansion;
                var minPlayers = 1;
                var maxPlayers = 4;
                var boardGameGeekReviewUrl = "http://boardgamegeek.com/boardgame/6472";
                var minPlayTime = 50;
                var maxPlayTime = 60;

                //Act
                var boardGameEntity = new BoardGame(boardGameName, boardGameGeekId, gameType, minPlayers, maxPlayers, boardGameGeekReviewUrl, minPlayTime, maxPlayTime);

                //Assert
                boardGameEntity.Name.Should().Be(boardGameName);
                boardGameEntity.BoardGameGeekId.Should().Be(boardGameGeekId);
                boardGameEntity.GameType.Should().Be(gameType);
                boardGameEntity.MinPlayers.Should().Be(minPlayers);
                boardGameEntity.MaxPlayers.Should().Be(maxPlayers);
                boardGameEntity.BoardGameGeekReviewUri.Should().Be(boardGameGeekReviewUrl);
                boardGameEntity.MinMinutesToPlay.Should().Be(minPlayTime);
                boardGameEntity.MaxMinutesToPlay.Should().Be(maxPlayTime);
            }
        }
    }
}
