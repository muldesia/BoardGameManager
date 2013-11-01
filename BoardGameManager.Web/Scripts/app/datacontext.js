"use strict";

var boardGameManager = boardGameManager || {};

boardGameManager.dataContext = (function() {
    var EntitySet = function (getFunction, mapper) {
        var cachedModelItems = [],
            _getFunction = getFunction,
            copyModelItemsToResults = function (models, observableArray) {
                if (!observableArray) {
                    throw 'copyModelItemsToResults() must be passed an observableArray as its second parameter.';
                }

                ko.utils.arrayPushAll(observableArray(), models);
                observableArray.valueHasMutated();
            },

            getData = function (options) {
                return $.Deferred(function (def) {
                    var results = options && options.results,
                        getFunctionOverride = options && options.getFunction,
                        getFunction = getFunctionOverride || _getFunction;

                    var useCache = true;
                    if (options && options.useCache) {
                        useCache = options.useCache;
                    }

                    if (areModelItemsInCache() && useCache) {
                        var modelItemsInCache = getCachedModelItems();
                        copyModelItemsToResults(modelItemsInCache, results);
                        def.resolve(results);
                    } else {
                        getFunction({
                            success: function (dtoList) {

                                if (localStorage) {
                                    localStorage.setItem('boardGames', JSON.stringify(dtoList));
                                }

                                cachedModelItems = mapDtoToModel(dtoList, mapper);
                                copyModelItemsToResults(cachedModelItems, results);

                                def.resolve(dtoList);
                            },
                            error: function (response) {
                                console.error('Unable to load data into dataContext.');
                                def.reject();
                            }
                        });
                    }

                }).promise();
            },

            getCachedModelItems = function () {
                if (cachedModelItems.length > 0) {
                    return cachedModelItems;
                }

                if (localStorage && localStorage.getItem('boardGames')) {
                    if (localStorage.getItem('boardGames').length > 0) {
                        var jsonObjectInLocalStorage = JSON.parse(window.localStorage.getItem('boardGames'));
                        return mapDtoToModel(jsonObjectInLocalStorage, mapper)
                    }
                }

                return null;
            },

            areModelItemsInCache = function () {
                if (cachedModelItems.length > 0) {
                    return true;
                }

                if (localStorage && localStorage.getItem('boardGames')) {
                    if (localStorage.getItem('boardGames').length > 0) {
                        return true;
                    }
                }

                return false;
            },

            mapDtoToModel = function (dtoList, mapper) {
                return _.map(dtoList, function (dto) {
                    return mapper.fromDto(dto);
                }, []);
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