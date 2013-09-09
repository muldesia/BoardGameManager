var boardGameManager = boardGameManager || {};

boardGameManager.modelMapper = (function () {
    var boardGames = {
        fromDto: function (dto, item) {
            item = item || new boardGameManager.model.BoardGames().id(dto.id);
            item.name(dto.name);
            item.dirtyFlat().reset();
            return item;
        }
    };

    return {
       boardGames: boardGames
    };
})();