﻿"use strict";

var boardGameManager = boardGameManager || {};
boardGameManager.model = boardGameManager.model || {};

boardGameManager.model.BoardGame = function () {
    var self = this;

    self.id = ko.observable(0);
    self.name = ko.observable('Null');
    self.boardGameGeekReviewUri = ko.observable('Null');
    self.boardGameGeekSmallImageUri = ko.observable('Null');
    self.boardGameGeekMediumImageUri = ko.observable('Null');
    self.boardGameGeekDescription = ko.observable('Null');
    self.gameType = ko.observable('Null');
    self.minPlayers = ko.observable(0);
    self.maxPlayers = ko.observable(0);
    self.minMinutesToPlay = ko.observable(0);
    self.maxMinutesToPlay = ko.observable(0);
    self.isNullo = true;

    return self;
};