var boardGameManager = boardGameManager || {};

boardGameManager.bootstrapper = (function() {
    var run = function() {
        boardGameManager.presenter.showWaitingIndicator();
        $.when(boardGameManager.dataprimer.fetchData())
            .done(binder.bind())
            .always(function() {
                boardGameManager.presenter.hideWaitingIndicator();
            });
    };

    return {
        run: run
    };
})();