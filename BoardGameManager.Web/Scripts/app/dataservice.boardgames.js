var boardGameManager = boardGameManager || {};
boardGameManager.dataService = boardGameManager.dataService || {};

boardGameManager.dataService.boardGames = (function() {
    var init = function() {
            //Resource Id, Request Type and Settings
            amplify.request.define('boardGames', 'ajax', {
                url: '/api/boardGames',
                dataType: 'json',
                type: 'GET'
                //cache: true
                //cache: 60000 //1 minute
                    //cache: 'persist'
            });
        },
        
        getBoardGames = function(callbacks) {
            return amplify.request({
                resourceId: 'boardGames',
                success: callbacks.success,
                error: callbacks.error
            });
        };

    init();

    return {
        init: init,
        getBoardGames: getBoardGames
    };
})();