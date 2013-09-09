var boardGameManager = boardGameManager || {};
boardGameManager.viewmodel = boardGameManager.viewmodel || {};
    
boardGameManager.viewmodel.boardGames = (function () {
    var refresh = function (callback) {
        $.when(boardGameManager.dataContext.boardGames.getData())
            .always(callback());
    };

    return {
        refresh: refresh
    };
})();