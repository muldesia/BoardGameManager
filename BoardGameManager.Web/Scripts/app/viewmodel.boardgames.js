"use strict";

var boardGameManager = boardGameManager || {};
boardGameManager.viewModel = boardGameManager.viewModel || {};
    
boardGameManager.viewModel.boardGames = (function () {
    var boardGames = ko.observableArray(),
        selectedGame = ko.observable(),
        numberOfPlayers = ko.observable(),

        refreshBoardGameList = function () {

            $.when(boardGameManager.viewModel.boardGames.hideBoardGameList(),
                boardGameManager.viewModel.boardGames.hideSelectedBoardGameDetails())
                .done(function () {
                    boardGameManager.viewModel.boardGames.showWaitingIndicator();

                    $.when(boardGameManager.dataContext.boardGames.getData({ results: boardGames }))
                        .done(function () {
                            boardGameManager.viewModel.boardGames.hideRetryLoadBoardGamesMessage();
                            boardGameManager.viewModel.boardGames.showBoardGameList();
                            boardGameManager.viewModel.boardGames.selectFirstGame();
                            boardGameManager.viewModel.boardGames.showSelectedBoardGameDetails();
                        })
                        .fail(function () {
                            boardGameManager.viewModel.boardGames.hideBoardGameList();
                            boardGameManager.viewModel.boardGames.showRetryLoadBoardGamesMessage();
                            boardGameManager.viewModel.boardGames.hideSelectedBoardGameDetails();
                        })
                        .always(function () {
                            boardGameManager.viewModel.boardGames.hideWaitingIndicator();
                        });
                });

            return;
        },

        isGameInsideFilter = function (filterValue, gameMinPlayers, gameMaxPlayers) {
            if (filterValue == "Any") {
                return true;
            }

            if (filterValue == "11+") {
                if (gameMaxPlayers >= 11) {
                    return true;
                } else {
                    return false;
                }

            }

            if (filterValue >= gameMinPlayers && filterValue <= gameMaxPlayers) {
                return true;
            }

            return false;
        },

        selectGame = function (data) {
            selectedGame(data);
        },

        selectFirstGame = function () {
            selectGame(boardGames()[0]);
        },

        showWaitingIndicator = function () {
            $('#waitingIndicatorContainer').show();
            $('#boardGameListWaitingIndicator').activity({ align: 'left' });
        },

        hideWaitingIndicator = function () {
            $('#boardGameListWaitingIndicator').activity(false);
            $('#waitingIndicatorContainer').hide();
        },

        showBoardGameList = function () {
            $('#boardGameList').show('blind', {}, 500, function () {
                var boardGameListUnorderedList = $('#boardGameList ul');
                boardGameListUnorderedList.css('overflow', 'auto'); //jQuery hide() changes the overflow style, so need to set it back.
                boardGameListUnorderedList.removeData('jsp'); //Removes reinitialisation problem with scroll bars
                boardGameListUnorderedList.jScrollPane({ mouseWheelSpeed: 60, autoReinitialise: true, contentWidth: 1 });
            });
        },

        hideBoardGameList = function () {
            return $('#boardGameList').hide(500).promise();
        },

        showSelectedBoardGameDetails = function () {
            $('#selectedBoardGameDetails').show('blind', {}, 500);
        },

        hideSelectedBoardGameDetails = function () {
            return $('#selectedBoardGameDetails').hide(500).promise();
        },

        showRetryLoadBoardGamesMessage = function () {
            $('#retryLoadBoardGamesMessage').show(500);
        },

        hideRetryLoadBoardGamesMessage = function () {
            $('#retryLoadBoardGamesMessage').hide(500);
        },

        refreshCache = function () {
            boardGameManager.dataContext.boardGames.clearCaches();
            refreshBoardGameList();
        }

    return {
        boardGames: boardGames,
        selectedGame: selectedGame,
        refreshBoardGameList: refreshBoardGameList,
        selectGame: selectGame,
        selectFirstGame: selectFirstGame,
        showWaitingIndicator: showWaitingIndicator,
        hideWaitingIndicator: hideWaitingIndicator,
        showSelectedBoardGameDetails: showSelectedBoardGameDetails,
        hideSelectedBoardGameDetails: hideSelectedBoardGameDetails,
        hideRetryLoadBoardGamesMessage: hideRetryLoadBoardGamesMessage,
        showRetryLoadBoardGamesMessage: showRetryLoadBoardGamesMessage,
        hideBoardGameList: hideBoardGameList,
        showBoardGameList: showBoardGameList,
        refreshCache: refreshCache,
        numberOfPlayers: numberOfPlayers,
        isGameInsideFilter: isGameInsideFilter
    };
})();