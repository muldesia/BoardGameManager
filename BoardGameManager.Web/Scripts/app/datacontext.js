var boardGameManager = boardGameManager || {};

boardGameManager.dataContext = (function() {
    var EntitySet = function (getFunction, mapper) {
        var items = [],
            _getFunction = getFunction,
            itemsToArray = function (items, observableArray) {
                if (!observableArray) return;

                ko.utils.arrayPushAll(observableArray(), items);
                observableArray.valueHasMutated();
            },

            getData = function (options) {
                return $.Deferred(function (def) {
                    var results = options && options.results,
                        getFunctionOverride = options && options.getFunction,
                        getFunction = getFunctionOverride || getFunction;

                    if (!items.length) {
                        _getFunction({
                            success: function (dtoList) {
                                items = mapToContext(dtoList, items, results, mapper);
                                def.resolve(dtoList);
                            },
                            error: function (response) {
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
            };

            return {
                getData: getData
            };

        },

        BoardGames = new EntitySet(boardGameManager.dataService.boardGames.getBoardGames, boardGameManager.modelMapper.boardGames);

    return {
        boardGames: BoardGames
    };
})();