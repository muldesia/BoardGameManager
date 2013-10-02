var boardGameManager = boardGameManager || {};
boardGameManager.model = boardGameManager.model || {};

boardGameManager.model.BoardGame = function () {
    var self = this;

    self.id = ko.observable(0);
    self.name = ko.observable('Null');
    self.minPlayers = ko.observable(0);
    self.maxPlayers = ko.observable(0);
    self.minMinutesToPlay = ko.observable(0);
    self.maxMinutesToPlay = ko.observable(0);
    self.boardGameGeekUrl = ko.observable('Null');
    self.isNullo = true;

    return self;
};