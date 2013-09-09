var boardGameManager = boardGameManager || {};

boardGameManager.binder = (function() {
    var ids = config.viewIds,
        bind = function() {
            ko.applyBindings(boardGameManager.viewmodel.boardGames, getView(ids.boardGames));
        },            
        getView = function(viewName) {
            return $(viewName).get(0);
        };

    return {
        bind: bind
    };
})();