var colors = require('colors');
var express = require('express');
var http = require('http');
var path = require('path');
var open = require('open');
var pjson = require('./package.json');

var routes = {};
routes.index = require('./routes/index');
routes.splash = require('./routes/splash');

var defaultPort = 8080;

console.log('[START] '.yellow + 'Break Time start-up');

var app = initExpress();
http.createServer(app).listen(app.get('port'), onServerStarted);

// Configure and initialise Express.
function initExpress()
{
  console.log('[START] '.yellow +  'Express configuration');
  var app = express();
  app.set('title', 'Break Time');
  app.set('version', pjson.version);
  app.set('port', process.env.PORT || defaultPort);
  app.set('views', path.join(__dirname, 'views'));
  app.set('view engine', 'jade');
  app.use(express.logger('dev'));
  app.use(express.favicon(path.join(__dirname, '/public/images/favicon.ico')));
  app.use(express.json());
  app.use(express.urlencoded());
  app.use(express.methodOverride());
  app.use(app.router);
  app.use(express.static('public'));

  if ('development' == app.get('env')) {
    app.use(express.errorHandler());
  }

  // Routes
  app.get('/', routes.index);
  app.get('/splash', routes.splash);

  console.log('[END] '.green + 'Express configuration');
  return app;
}

// Open home page when server has started.
function onServerStarted()
{
  console.log('Web server started and listening on port ' + app.get('port') + '.');
  console.log('[START] '.yellow + 'Open home page');
  open('http://localhost:' + app.get('port'));
  console.log('[END] '.green + 'Open home page');
  console.log('[END] '.green + 'Break Time start-up');
}
