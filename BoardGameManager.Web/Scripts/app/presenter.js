﻿var boardGameManager = boardGameManager || {};

boardGameManager.presenter = (function() {
    var showWaitingIndicator = function () {
        $('.waitingIndicator').activity();
    };

    var hideWaitingIndicator = function () {
        $('.waitingIndicator').activity(false);
    };

    return {
        showWaitingIndicator: showWaitingIndicator,
        hideWaitingIndicator: hideWaitingIndicator
    };
})();