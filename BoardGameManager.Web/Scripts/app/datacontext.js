var boardGameManager = boardGameManager || {};

boardGameManager.dataContext = (function() {
    var EntitySet = function (getFunction, mapper) {
        var items = {},

            itemsToArray = function (items, observableArray) {
                if (!observableArray) return;

                var underlyingArray = boardGameManager.utils.mapMemoToArray(items);

                observableArray(underlyingArray);
            },

            getData = function (options) {
                return $.Deferred(function (def) {
                    var results = options && options.results,
                        getFunctionOverride = options && options.getFunction,
                        getFunction = getFunctionOverride || getFunction;

                    if (!items) {
                        getFunction({
                            success: function (dtoList) {
                                items = mapToContext(dtoList, items, results, mapper);
                                def.resolve(dtoList);
                            },
                            error: function (response) {

                            }
                        });
                    } else {
                        itemsToArray(items, results);
                        def.resolve(results);
                    }
                }).promise();
            },

            mapToContext = function (dtoList, items, results, mapper) {
                items = _.reduce(dtoList, function (memo, dto) {
                    var id = mapper.getDtoId(dto);
                    var existingItem = items[id];
                    memo[id] = mapper.fromDto(dto, existingItem);
                    return memo;
                }, {});
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