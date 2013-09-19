var boardGameManager = boardGameManager || {};
boardGameManager.viewModel = boardGameManager.viewModel || {};
    
boardGameManager.viewModel.boardGames = (function () {
    var boardGames = ko.observableArray(),
        selectedGame = ko.observable(),
        refresh = function (callback) {
            return boardGameManager.dataContext.boardGames.getData({ results: boardGames });
        };

    return {
        boardGames: boardGames,
        selectedGame : selectedGame,
        refresh: refresh
    };
})();