var boardGameManager = boardGameManager || {};
boardGameManager.model = boardGameManager.model || {};

boardGameManager.model.boardGame = (function () {
    var _dataContext,

        BoardGame = function () {
            var self = this;
            self.id = ko.observable();
            self.name = ko.observable();
            self.isNullo = false;
            return self;
        };  

    BoardGame.Nullo = new BoardGame().id(0).name('Null');
    BoardGame.Nullo.isNullo = true;

    BoardGame.datacontext = function (dataContext) {
        if (dataContext) {
            _dataContext = dataContext;
        }

        return _dataContext;
    };

    BoardGame.prototype = function () {
        boardGame = function () {
            return dataContext().boardGame; //getLocalById()?
        };
    };

    return {
        BoardGame: BoardGame
    };
})();