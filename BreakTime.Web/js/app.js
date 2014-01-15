requirejs.config({ baseUrl: 'js/app' });

requirejs(["utils", "main"],
          function(utils, main) {
            main.init();
          });
