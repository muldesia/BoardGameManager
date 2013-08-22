define('bootstrapper',
    [],
    function() {
        var run = function() {
            alert('hello!');
        };

        return {
            run: run
        };
    });