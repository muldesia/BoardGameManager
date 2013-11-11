"use strict";

var boardGameManager = boardGameManager || {};

boardGameManager.modelMapper = (function () {
    var boardGames = {
        fromDto: function (dto) {
            var item = new boardGameManager.model.BoardGame();
                item.id(dto.boardGameId);
                item.name(dto.name);
                item.gameType(dto.gameType);
                item.boardGameGeekReviewUri(dto.boardGameGeekReviewUri);
                item.boardGameGeekSmallImageUri(dto.boardGameGeekSmallImageUri);
                item.boardGameGeekMediumImageUri(dto.boardGameGeekMediumImageUri);
                item.boardGameGeekDescription(dto.boardGameGeekDescription);
                item.minPlayers(dto.minPlayers);
                item.maxPlayers(dto.maxPlayers);
                item.minMinutesToPlay(dto.minMinutesToPlay);
                item.maxMinutesToPlay(dto.maxMinutesToPlay);

                //item.dirtyFlag().reset();
            return item;
        },

        getDtoId: function (dto) {
            return dto.boardGameId;
        }
    };
  
    return {
       boardGames: boardGames
    };
})();