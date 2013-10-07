module('viewmodel.boardgames');

test('showWaitingIndicator() calls activity(<not false>) on waiting indicator div to display Net Eye', sinon.test( function() {
    //Arrange
    var jQueryMethods = { activity: function (value) { } };

    var jQueryStub = this.stub(window, '$');
    jQueryStub.withArgs('#boardGameListWaitingIndicator').returns(jQueryMethods);

    var waitingIndicatorActivityMethodSpy = this.spy(jQueryMethods, 'activity');

    //Act
    boardGameManager.viewModel.boardGames.showWaitingIndicator();

    //Assert
    sinon.assert.calledOnce(waitingIndicatorActivityMethodSpy);
    sinon.assert.neverCalledWith(waitingIndicatorActivityMethodSpy, false);
}));

test('hideWaitingIndicator() calls activity(false) on waiting indicator div to hide Net Eye', sinon.test(function () {
    //Arrange
    var jQueryMethods = { activity: function (value) { } };

    var jQueryStub = this.stub(window, '$');
    jQueryStub.withArgs('#boardGameListWaitingIndicator').returns(jQueryMethods);

    var waitingIndicatorActivityMethodSpy = this.spy(jQueryMethods, 'activity');

    //Act
    boardGameManager.viewModel.boardGames.hideWaitingIndicator();

    //Assert
    sinon.assert.calledOnce(waitingIndicatorActivityMethodSpy);
    sinon.assert.calledWith(waitingIndicatorActivityMethodSpy, false);
}));

test('selectGame(game) sets the selectedGame observable to the game passed in', sinon.test(function () {
    //Arrange
    boardGameManager.viewModel.boardGames.selectedGame('game2');

    //Act
    boardGameManager.viewModel.boardGames.selectGame('game1');

    //Assert
    strictEqual(boardGameManager.viewModel.boardGames.selectedGame(), 'game1', 'The selectedGame observable on the view model has been updated successfully by the selectGame(game) method.')
}));

test('selectFirstGame() sets the selectedGame observable to the first game in the observable array boardGames', sinon.test(function () {
    //Arrange
    boardGameManager.viewModel.boardGames.boardGames(['game1', 'game2', 'game3', 'game4']);
    boardGameManager.viewModel.boardGames.selectedGame('game3');

    //Act
    boardGameManager.viewModel.boardGames.selectFirstGame();

    //Assert
    strictEqual(boardGameManager.viewModel.boardGames.selectedGame(), 'game1', 'The selectedGame observable on the view model has been updated correctly by selectFirstGame().')
}));

test('refreshBoardGameList() when games load successfully', sinon.test(function () {
    //Arrange
    var showWaitingIndicatorMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'showWaitingIndicator');
    var hideWaitingIndicatorMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'hideWaitingIndicator');
    var dataContextMock = this.mock(boardGameManager.dataContext.boardGames);
    var getDataCallExpectations = dataContextMock.expects('getData').once().withArgs(sinon.match.has('results')).returns($.when(true));
    var showBoardGameListMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'showBoardGameList');
    var selectFirstGameMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'selectFirstGame');
    var showSelectedBoardGameDetailsMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'showSelectedBoardGameDetails');
    var hideRetryLoadBoardGamesMessageMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'hideRetryLoadBoardGamesMessage');

    //Act
    var results = boardGameManager.viewModel.boardGames.refreshBoardGameList();

    //Assert
    sinon.assert.calledOnce(showWaitingIndicatorMethodStub);
    getDataCallExpectations.verify();
    sinon.assert.calledOnce(showBoardGameListMethodStub);
    sinon.assert.calledOnce(selectFirstGameMethodStub);
    sinon.assert.calledOnce(showSelectedBoardGameDetailsMethodStub);
    sinon.assert.calledOnce(hideRetryLoadBoardGamesMessageMethodStub);
    sinon.assert.calledOnce(hideWaitingIndicatorMethodStub)
    sinon.assert.callOrder(showWaitingIndicatorMethodStub, hideWaitingIndicatorMethodStub);
}));

test('refreshBoardGameList() when games DO NOT load successfully', sinon.test(function () {
    //Arrange
    var showWaitingIndicatorMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'showWaitingIndicator');
    var hideWaitingIndicatorMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'hideWaitingIndicator');
    var dataContextMock = this.mock(boardGameManager.dataContext.boardGames);
    var getDataCallExpectations = dataContextMock.expects('getData').once().withArgs(sinon.match.has('results')).returns(new $.Deferred().reject().promise());
    var hideBoardGameListMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'hideBoardGameList');
    var selectFirstGameMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'selectFirstGame');
    var hideSelectedBoardGameDetailsMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'hideSelectedBoardGameDetails');
    var showRetryLoadBoardGamesMessageMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'showRetryLoadBoardGamesMessage');

    //Act
    var results = boardGameManager.viewModel.boardGames.refreshBoardGameList();

    //Assert
    sinon.assert.calledOnce(showWaitingIndicatorMethodStub);
    getDataCallExpectations.verify();
    sinon.assert.calledOnce(hideBoardGameListMethodStub);
    sinon.assert.calledOnce(showRetryLoadBoardGamesMessageMethodStub);
    sinon.assert.calledOnce(hideSelectedBoardGameDetailsMethodStub);
    sinon.assert.calledOnce(hideWaitingIndicatorMethodStub);
    sinon.assert.callOrder(showWaitingIndicatorMethodStub, hideWaitingIndicatorMethodStub);
}));
