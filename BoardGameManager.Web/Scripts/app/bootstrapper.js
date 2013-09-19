var boardGameManager = boardGameManager || {};

boardGameManager.bootstrapper = (function() {
    var run = function() {
        boardGameManager.presenter.showWaitingIndicator();
        $.when(boardGameManager.viewModel.boardGames.refresh())
            .always(function() {
                boardGameManager.binder.bind();
                boardGameManager.presenter.hideWaitingIndicator();
            });
    };
    
    return {
        run: run
    };
})();