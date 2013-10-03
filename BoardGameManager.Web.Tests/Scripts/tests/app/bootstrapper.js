module('bootstrapper');

test('run(): When viewmodel calls refresh() successfully, first game selected and wait indicator hidden', sinon.test(function () {
    //Arrange
    this.stub(boardGameManager.viewModel.boardGames, 'showWaitingIndicator');
    this.stub(boardGameManager.binder, 'bind');
    var viewModelRefreshMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'refresh').returns($.when(true));
    var viewModelSelectFirstGameMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'selectFirstGame');
    var viewModelHideWaitingIndicatorMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'hideWaitingIndicator');

    //Act
    boardGameManager.bootstrapper.run();

    //Assert
    sinon.assert.calledOnce(viewModelRefreshMethodStub);
    sinon.assert.calledOnce(viewModelSelectFirstGameMethodStub);
    sinon.assert.calledOnce(viewModelHideWaitingIndicatorMethodStub);
}));

test('run(): When viewmodel calls refresh() unsuccessfully, first game it NOT selected but wait indicator is still hidden', sinon.test(function () {
    //Arrange
    this.stub(boardGameManager.viewModel.boardGames, 'showWaitingIndicator');
    this.stub(boardGameManager.binder, 'bind');
    var viewModelRefreshMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'refresh').returns(new $.Deferred().reject().promise());
    var viewModelSelectFirstGameMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'selectFirstGame');
    var viewModelHideWaitingIndicatorMethodStub = this.stub(boardGameManager.viewModel.boardGames, 'hideWaitingIndicator');

    //Act
    boardGameManager.bootstrapper.run();

    //Assert
    sinon.assert.calledOnce(viewModelRefreshMethodStub);
    sinon.assert.notCalled(viewModelSelectFirstGameMethodStub);
    sinon.assert.calledOnce(viewModelHideWaitingIndicatorMethodStub);
}));