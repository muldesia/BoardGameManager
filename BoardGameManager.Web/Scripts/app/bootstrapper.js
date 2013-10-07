"use strict";

var boardGameManager = boardGameManager || {};

boardGameManager.bootstrapper = (function() {
    var run = function () {
        boardGameManager.binder.bind();
        boardGameManager.viewModel.boardGames.refreshBoardGameList();
    };
    
    return {
        run: run
    };
})();