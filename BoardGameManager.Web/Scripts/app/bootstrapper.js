var boardGameManager = boardGameManager || {};

boardGameManager.bootstrapper = (function() {
    var run = function() {
        console.debug('Running bootstrapper.');
        boardGameManager.viewModel.boardGames.showWaitingIndicator();
        boardGameManager.binder.bind();
        console.debug('Attempting to refresh the board games view model.');
        $.when(boardGameManager.viewModel.boardGames.refresh())
            .done(function () {
                console.debug('Loaded board games into view model.');
                boardGameManager.viewModel.boardGames.selectFirstGame();
            })
            .always(function() {
                console.debug('Hiding wait indicator.');
                boardGameManager.viewModel.boardGames.hideWaitingIndicator();
            });

        console.debug('Bootstrapper finished running.');
    };
    
    return {
        run: run
    };
})();