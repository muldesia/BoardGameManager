var boardGameManager = boardGameManager || {};
boardGameManager.viewModel = boardGameManager.viewModel || {};
    
boardGameManager.viewModel.boardGames = (function () {
    var boardGames = ko.observableArray(),
        selectedGame = ko.observable(),
        
        refresh = function (callback) {
            return boardGameManager.dataContext.boardGames.getData({ results: boardGames });
        },
        
        selectGame = function (data, Event) {
            selectedGame(data);
        },
        
        selectFirstGame = function(){
            selectGame(boardGames()[0]);
        },
        
        showWaitingIndicator = function () {
            $('#boardGameListWaitingIndicator').activity(true);
        },

        hideWaitingIndicator = function () {
            $('#boardGameListWaitingIndicator').activity(false);
        };

    return {
        boardGames: boardGames,
        selectedGame : selectedGame,
        refresh: refresh,
        selectGame: selectGame,
        selectFirstGame: selectFirstGame,
        showWaitingIndicator: showWaitingIndicator,
        hideWaitingIndicator: hideWaitingIndicator
    };
})();