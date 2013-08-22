(function () {
    var root = this;

    requirejs.config(
        {
            baseUrl: 'app',
            paths: {
                'jquery': 'jquery-2.0.3'
            }
        }
    );

    define3rdPartyModules();
    loadPluginsAndBoot();
    
    function define3rdPartyModules() {
        // These are already loaded via bundles.
        // We define them and put them in the root object.
        define('jquery', [], function() { return root.jQuery; });
        define('ko', [], function () { return root.ko; });
        define('amplify', [], function () { return root.amplify; });
        //MORE IN NOTES
    }
    
    function loadPluginsAndBoot() {
        // Plugins must be loaded after jQuery and Knockout,
        // since they depend on them.
        requirejs([
            'jquery.activity-ex'
            //MORE IN NOTES
        ], boot);
    }

    function boot() {
        require(['bootstrapper'],
            function (bootstrapper) {
                bootstrapper.run();
            });
    }
})();