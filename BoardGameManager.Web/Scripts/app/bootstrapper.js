var boardGameManager = boardGameManager || {};

boardGameManager.bootstrapper = (function() {
    var run = function() {
        boardGameManager.presenter.showWaitingIndicator();
        $.when(boardGameManager.dataPrimer.fetchData())
            .done(boardGameManager.viewModel.boardGames.refresh())
            .done(boardGameManager.binder.bind())
            .always(function() {
                boardGameManager.presenter.hideWaitingIndicator();
            });
    };

    return {
        run: run
    };
})();