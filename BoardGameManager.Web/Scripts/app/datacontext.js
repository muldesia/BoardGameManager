"use strict";

var boardGameManager = boardGameManager || {};

boardGameManager.dataContext = (function() {
    var EntitySet = function (entitySetName, getFunction, mapper) {
        var cachedModelItems = [],
            _getFunction = getFunction,

            copyModelItemsToResults = function (models, observableArray) {
                if (!observableArray) {
                    throw 'copyModelItemsToResults() must be passed an observableArray as its second parameter.';
                }

                observableArray([]);
                ko.utils.arrayPushAll(observableArray(), models);
                observableArray.valueHasMutated();
            },

            getData = function (options) {
                return $.Deferred(function (def) {
                    var results = options && options.results,
                        getFunctionOverride = options && options.getFunction,
                        getFunction = getFunctionOverride || _getFunction;

                    if (areModelItemsInCache()) {
                        var modelItemsInCache = getCachedModelItems();
                        copyModelItemsToResults(modelItemsInCache, results);
                        def.resolve(results);
                    } else {
                        getFunction({
                            success: function (dtoList) {

                                setInLocalStorage(dtoList);

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

            setInLocalStorage = function (jsonObject) {
                if (localStorage) {
                    localStorage.setItem('EntitySet_' + entitySetName, JSON.stringify(jsonObject));
                }
            },

            getModelFromLocalStorage = function () {
                if (localStorage && localStorage.getItem('EntitySet_' + entitySetName)) {
                    if (localStorage.getItem('EntitySet_' + entitySetName).length > 0) {
                        var jsonObjectInLocalStorage = JSON.parse(window.localStorage.getItem('EntitySet_' + entitySetName));
                        return mapDtoToModel(jsonObjectInLocalStorage, mapper)
                    }
                }

                return null;
            },

            removeModelFromLocalStorage = function () {
                if (localStorage && localStorage.getItem('EntitySet_' + entitySetName)) {
                    localStorage.removeItem('EntitySet_' + entitySetName);
                }
            },

            getCachedModelItems = function () {
                if (cachedModelItems.length > 0) {
                    return cachedModelItems;
                }
                
                return getModelFromLocalStorage();
            },

            areModelItemsInCache = function () {
                if (cachedModelItems.length > 0) {
                    return true;
                }

                if (localStorage && localStorage.getItem('EntitySet_' + entitySetName)) {
                    if (localStorage.getItem('EntitySet_' + entitySetName).length > 0) {
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

            clearCaches = function () {
                cachedModelItems = [];
                removeModelFromLocalStorage();
            };

            return {
                getData: getData,
                clearCaches: clearCaches
            };

        },

        BoardGames = new EntitySet('boardGames', boardGameManager.dataService.boardGames.getBoardGames, boardGameManager.modelMapper.boardGames);

    return {
        boardGames: BoardGames
    };
})();