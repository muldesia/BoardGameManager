var boardGameManager = boardGameManager || {};

boardGameManager.dataPrimer = (function() {
    var fetchData = function() {
        return $.Deferred(function(def) {
            var data = {
                boardGames: ko.observable()
            };

            $.when(
                //dataContext.boardGames.getData({ results: data.boardGames })
            ).fail(function() { def.reject(); })
             .done(function() { def.resolve(); });
        }).promise();
    };

    return {
        fetchData: fetchData
    };
})();
