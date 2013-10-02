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