var boardGameManager = boardGameManager || {};

boardGameManager.modelMapper = (function () {
    var boardGames = {
        fromDto: function (dto) {
            var item = new boardGameManager.model.BoardGame();
                item.id(dto.boardGameId);
                item.name(dto.name);
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