module('modelmapper');

test('fromDto(): Takes DTO containing one board game, and converts to BoardGame object ', sinon.test(function () {
    //Arrange
    var dto = {
        boardGameId: 1,
        name: 'name',
        boardGameGeekId: 5,
        gameType: 0,
        minPlayers: 'minPlayers',
        maxPlayers: 'maxPlayers',
        minMinutesToPlay: 'minMinutesToPlay',
        maxMinutesToPlay: 'maxMinutesToPlay'
    };

    //Act
    var boardGame = boardGameManager.modelMapper.boardGames.fromDto(dto);

    //Assert
    strictEqual(boardGame.id(), 1);
    strictEqual(boardGame.name(), 'name');
    strictEqual(boardGame.boardGameGeekReviewUrl(), 'http://boardgamegeek.com/boardgame/5');
    strictEqual(boardGame.boardGameGeekSmallImageUrl(), 'http://cf.geekdo-images.com/images/pic5_sq.jpg');
    strictEqual(boardGame.gameType(), 0);
    strictEqual(boardGame.minPlayers(), 'minPlayers');
    strictEqual(boardGame.maxPlayers(), 'maxPlayers');
    strictEqual(boardGame.minMinutesToPlay(), 'minMinutesToPlay');
    strictEqual(boardGame.maxMinutesToPlay(), 'maxMinutesToPlay');
}));

test('fromDto(): Takes DTO containing one EXPANSION board game, and converts to BoardGame object ', sinon.test(function () {
    //Arrange
    var dto = {
        boardGameId: 1,
        name: 'name',
        boardGameGeekId: 6,
        gameType: 1,
        minPlayers: 'minPlayers',
        maxPlayers: 'maxPlayers',
        minMinutesToPlay: 'minMinutesToPlay',
        maxMinutesToPlay: 'maxMinutesToPlay'
    };

    //Act
    var boardGame = boardGameManager.modelMapper.boardGames.fromDto(dto);

    //Assert
    strictEqual(boardGame.id(), 1);
    strictEqual(boardGame.name(), 'name');
    strictEqual(boardGame.boardGameGeekReviewUrl(), 'http://boardgamegeek.com/boardgameexpansion/6');
    strictEqual(boardGame.boardGameGeekSmallImageUrl(), 'http://cf.geekdo-images.com/images/pic6_sq.jpg');
    strictEqual(boardGame.gameType(), 1);
    strictEqual(boardGame.minPlayers(), 'minPlayers');
    strictEqual(boardGame.maxPlayers(), 'maxPlayers');
    strictEqual(boardGame.minMinutesToPlay(), 'minMinutesToPlay');
    strictEqual(boardGame.maxMinutesToPlay(), 'maxMinutesToPlay');
}));

test('getDtoId', sinon.test(function () {
    //Arrange
    var dto = {
        boardGameId: 1,
        name: 'name',
        boardGameGeekId: 5,
        gameType: 1,
        minPlayers: 'minPlayers',
        maxPlayers: 'maxPlayers',
        minMinutesToPlay: 'minMinutesToPlay',
        maxMinutesToPlay: 'maxMinutesToPlay',
        boardGameGeekUrl: 'boardGameGeekUrl'
    };

    //Act
    var id = boardGameManager.modelMapper.boardGames.getDtoId(dto);

    //Assert
    strictEqual(id, 1);
}));
