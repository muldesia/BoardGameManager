"use strict";

var boardGameManager = boardGameManager || {};

boardGameManager.binder = (function() {
    var 
        bind = function () {
            ko.applyBindings(boardGameManager.viewModel.boardGames);
        };

    return {
        bind: bind
    };
})();