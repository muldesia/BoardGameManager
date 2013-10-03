module('viewmodel.boardgames');

test('showWaitingIndicator() calls activity(true) on waiting indicator div', sinon.test( function() {
    //Arrange
    var jQueryMethods = { activity: function (value) { } };

    var jQueryStub = this.stub(window, '$');
    jQueryStub.withArgs('#boardGameListWaitingIndicator').returns(jQueryMethods);

    var waitingIndicatorMock = this.mock(jQueryMethods);
    var expectation = waitingIndicatorMock.expects('activity').once().withArgs(true);

    //Act
    boardGameManager.viewModel.boardGames.showWaitingIndicator();

    //Assert
    expectation.verify();
    sinon.assert.calledWith(jQueryStub, '#boardGameListWaitingIndicator');
}));

test('hideWaitingIndicator() calls activity(false) on waiting indicator div', sinon.test(function () {
    //Arrange
    var jQueryMethods = { activity: function (value) { } };

    var jQueryStub = this.stub(window, '$');
    jQueryStub.withArgs('#boardGameListWaitingIndicator').returns(jQueryMethods);

    var waitingIndicatorMock = this.mock(jQueryMethods);
    var expectation = waitingIndicatorMock.expects('activity').once().withArgs(false);

    //Act
    boardGameManager.viewModel.boardGames.hideWaitingIndicator();

    //Assert
    expectation.verify();
    sinon.assert.calledWith(jQueryStub, '#boardGameListWaitingIndicator');
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

test('resfresh() calls getData() on the datacontext for board games', sinon.test(function () {
    //Arrange
    var dataContextMock = this.mock(boardGameManager.dataContext.boardGames);
    var expectedDataReturned = 'some data';
    var expectations = dataContextMock.expects('getData').once().withArgs(sinon.match.has('results')).returns(expectedDataReturned);;

    //Act
    var results = boardGameManager.viewModel.boardGames.refresh();

    //Assert
    expectations.verify();
    strictEqual(results, expectedDataReturned);
}));