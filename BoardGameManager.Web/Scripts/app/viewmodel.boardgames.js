"use strict";

var boardGameManager = boardGameManager || {};
boardGameManager.viewModel = boardGameManager.viewModel || {};
    
boardGameManager.viewModel.boardGames = (function () {
    var boardGames = ko.observableArray(),
        selectedGame = ko.observable(),

        refreshBoardGameList = function () {
            boardGameManager.viewModel.boardGames.showWaitingIndicator();
            $.when(boardGameManager.dataContext.boardGames.getData({ results: boardGames }))
                .done(function () {
                    boardGameManager.viewModel.boardGames.showBoardGameList();
                    boardGameManager.viewModel.boardGames.selectFirstGame();
                    boardGameManager.viewModel.boardGames.showSelectedBoardGameDetails();
                    boardGameManager.viewModel.boardGames.hideRetryLoadBoardGamesMessage();
                })
                .fail(function () {
                    boardGameManager.viewModel.boardGames.hideBoardGameList();
                    boardGameManager.viewModel.boardGames.showRetryLoadBoardGamesMessage();
                    boardGameManager.viewModel.boardGames.hideSelectedBoardGameDetails();
                })
                .always(function () {
                    boardGameManager.viewModel.boardGames.hideWaitingIndicator();
                });
            return;
        },

        selectGame = function (data) {
            selectedGame(data);
        },

        selectFirstGame = function () {
            selectGame(boardGames()[0]);
        },

        showWaitingIndicator = function () {
            $('#boardGameListWaitingIndicator').activity({ align: 'left' });
        },

        hideWaitingIndicator = function () {
            $('#boardGameListWaitingIndicator').activity(false);
        },

        showBoardGameList = function () {
            $('#boardGameList').show('blind', {}, 500, function () {
                $('#boardGameList ul').jScrollPane();
            });
        },

        hideBoardGameList = function () {
            $('#boardGameList').hide(500);
        },

        showSelectedBoardGameDetails = function () {
            $('#selectedBoardGameDetails').show('blind', {}, 500);
        },

        hideSelectedBoardGameDetails = function () {
            $('#selectedBoardGameDetails').hide(500);
        },

        showRetryLoadBoardGamesMessage = function () {
            $('#retryLoadBoardGamesMessage').show(500);
        },

        hideRetryLoadBoardGamesMessage = function () {
            $('#retryLoadBoardGamesMessage').hide(500);
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
        showBoardGameList: showBoardGameList
    };
})();