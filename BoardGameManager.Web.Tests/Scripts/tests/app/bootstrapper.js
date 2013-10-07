module('bootstrapper');

test('run(): should call bind() and refresh() on the view model.', sinon.test(function () {
    //Arrange
    this.stub(boardGameManager.binder, 'bind');
    var viewModelRefreshMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'refreshBoardGameList');

    //Act
    boardGameManager.bootstrapper.run();

    //Assert
    sinon.assert.calledOnce(viewModelRefreshMethodStub);
}));
