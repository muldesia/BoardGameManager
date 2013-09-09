var boardGameManager = boardGameManager || {};
boardGameManager.viewModel = boardGameManager.viewModel || {};
    
boardGameManager.viewModel.boardGames = (function () {
    var boardGames = ko.observableArray(),
        refresh = function (callback) {
            $.when(boardGameManager.dataContext.boardGames.getData(boardGames));
                //.always(callback());
        };

    return {
        refresh: refresh,
        boardGames: boardGames
    };
})();