module('datacontext');

asyncTest('getData() receives board games from the data service, and copies them into the observable array passed in', sinon.test(function () {
    //Arrange
    var results = ko.observableArray();

    var boardGamesListJsonFromServer = [
        {
            "boardGameId":1,
            "name":"A Game Of Thrones: The Board Game",
            "boardGameGeekId":6472,
            "gameType":0,
            "minPlayers":3,
            "maxPlayers":5,
            "minMinutesToPlay":120,
            "maxMinutesToPlay":180
        },
        {
            "boardGameId":2,
            "name":"Dominion",
            "boardGameGeekId":36218,
            "gameType":0,
            "minPlayers":2,
            "maxPlayers":4,
            "minMinutesToPlay":30,
            "maxMinutesToPlay":30
        }];

    var dummyDataServiceImplementation = function (callbacks)
        {
            callbacks.success(boardGamesListJsonFromServer);
        };
    var dataServiceGetBoardGamesMethodStub = this.stub(boardGameManager.dataService.boardGames, 'getBoardGames', dummyDataServiceImplementation);

    var modelMapperFromDtoMethodStub = this.stub(boardGameManager.modelMapper.boardGames, 'fromDto');

    var boardGame1Model = new boardGameManager.model.BoardGame();
    boardGame1Model.id(1);
    boardGame1Model.name('A Game Of Thrones: The Board Game');
    boardGame1Model.boardGameGeekId(6472);
    boardGame1Model.gameType(0);
    boardGame1Model.minPlayers(3);
    boardGame1Model.maxPlayers(5);
    boardGame1Model.minMinutesToPlay(120);
    boardGame1Model.maxMinutesToPlay(180);

    modelMapperFromDtoMethodStub.withArgs({
        "boardGameId": 1,
        "name": "A Game Of Thrones: The Board Game",
        "boardGameGeekId": 6472,
        "gameType": 0,
        "minPlayers": 3,
        "maxPlayers": 5,
        "minMinutesToPlay": 120,
        "maxMinutesToPlay": 180
    }).returns(boardGame1Model);

    var boardGame2Model = new boardGameManager.model.BoardGame();
    boardGame2Model.id(2);
    boardGame2Model.name('Dominion');
    boardGame2Model.boardGameGeekId(36218);
    boardGame2Model.gameType(0);
    boardGame2Model.minPlayers(2);
    boardGame2Model.maxPlayers(4);
    boardGame2Model.minMinutesToPlay(30);
    boardGame2Model.maxMinutesToPlay(30);

    modelMapperFromDtoMethodStub.withArgs({
        "boardGameId": 2,
        "name": "Dominion",
        "boardGameGeekId": 36218,
        "gameType": 0,
        "minPlayers": 2,
        "maxPlayers": 4,
        "minMinutesToPlay": 30,
        "maxMinutesToPlay": 30,
    }).returns(boardGame2Model);

    var options = { results: results, getFunction: boardGameManager.dataService.boardGames.getBoardGames };

    boardGameManager.dataContext.boardGames.clearCache();

    //Act
    var promise = boardGameManager.dataContext.boardGames.getData(options);

    //Assert
    $.when(promise)
        .done(function () {
            strictEqual(results()[0].id(), 1);
            strictEqual(results()[0].name(), 'A Game Of Thrones: The Board Game');
            strictEqual(results()[0].boardGameGeekId(), 6472);
            strictEqual(results()[0].gameType(), 0);
            strictEqual(results()[0].minPlayers(), 3);
            strictEqual(results()[0].maxPlayers(), 5);
            strictEqual(results()[0].minMinutesToPlay(), 120);
            strictEqual(results()[0].maxMinutesToPlay(), 180);

            strictEqual(results()[1].id(), 2);
            strictEqual(results()[1].name(), 'Dominion');
            strictEqual(results()[1].boardGameGeekId(), 36218);
            strictEqual(results()[1].gameType(), 0);
            strictEqual(results()[1].minPlayers(), 2);
            strictEqual(results()[1].maxPlayers(), 4);
            strictEqual(results()[1].minMinutesToPlay(), 30);
            strictEqual(results()[1].maxMinutesToPlay(), 30);
        })
        .fail(function () {
            ok(true, 'Promise returned from data context getData() resulted in fail() callback being called which it should not have.');
        })
        .always(function () {
            start();
        });
}));


asyncTest('getData() fails to get any games from the data service', sinon.test(function () {
    //Arrange
    var results = ko.observableArray();

    var dummyDataServiceImplementation = function (callbacks) {
        callbacks.error('Failed to get any games from the data service');
    };
    var dataServiceGetBoardGamesMethodStub = this.stub(boardGameManager.dataService.boardGames, 'getBoardGames', dummyDataServiceImplementation);

    var options = { results: results, getFunction: boardGameManager.dataService.boardGames.getBoardGames };

    boardGameManager.dataContext.boardGames.clearCache();

    //Act
    var promise = boardGameManager.dataContext.boardGames.getData(options);

    //Assert
    $.when(promise)
        .fail(function () {
            ok(true, 'Promise returned from data context getData() resulted in fail() callback being called.');
        })
        .done(function () {
            ok(false, 'Promise returned from data context getData() resulted in done() callback being called and it should not have.')
        })
        .always(function () {
            start();
        });
}));
