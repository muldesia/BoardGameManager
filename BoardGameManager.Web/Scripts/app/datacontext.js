"use strict";

var boardGameManager = boardGameManager || {};

boardGameManager.dataContext = (function() {
    var EntitySet = function (getFunction, mapper) {
        var items = [],
            _getFunction = getFunction,
            itemsToArray = function (items, observableArray) {
                if (!observableArray) {
                    throw 'itemsToArray() must be passed an observableArray as its second parameter.';
                }

                ko.utils.arrayPushAll(observableArray(), items);
                observableArray.valueHasMutated();
            },

            getData = function (options) {
                return $.Deferred(function (def) {
                    var results = options && options.results,
                        getFunctionOverride = options && options.getFunction,
                        getFunction = getFunctionOverride || _getFunction;

                    if (!items.length) {
                        getFunction({
                            success: function (dtoList) {
                                items = mapToContext(dtoList, items, results, mapper);
                                def.resolve(dtoList);
                            },
                            error: function (response) {
                                console.error('Unable to load data into dataContext.');
                                def.reject(); // ?
                            }
                        });
                    } else {
                        itemsToArray(items, results);
                        def.resolve(results);
                    }
                }).promise();
            },

            mapToContext = function (dtoList, items, results, mapper) {
                items = _.map(dtoList, function (dto) {
                    return mapper.fromDto(dto);
                }, []);
                itemsToArray(items, results);
                return items;
            },

            clearCache = function () {
                items = [];
            };

            return {
                getData: getData,
                clearCache: clearCache
            };

        },

        BoardGames = new EntitySet(boardGameManager.dataService.boardGames.getBoardGames, boardGameManager.modelMapper.boardGames);

    return {
        boardGames: BoardGames
    };
})();