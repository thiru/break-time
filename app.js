var colors = require('colors');
var express = require('express');
var http = require('http');
var path = require('path');
var open = require('open');
var routes = require('./routes');

console.log('[START] '.yellow + 'Break Time start-up');
console.log('[START] '.yellow +  'Express configuration');
var defaultPort = 8080;
var app = express();

app.set('port', process.env.PORT || defaultPort);
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'jade');
app.use(express.logger('dev'));
app.use(express.favicon(__dirname + '/public/images/favicon.ico'));
app.use(express.json());
app.use(express.urlencoded());
app.use(express.methodOverride());
app.use(app.router);
app.use(express.static('public'));

if ('development' == app.get('env')) {
  app.use(express.errorHandler());
}

app.set('title', 'Break Time');
app.get('/', routes.index);
console.log('[END] '.green + 'Express configuration');

http.createServer(app).listen(app.get('port'), function() {
  console.log('Express server started and listening on port ' + app.get('port') + '.');
  console.log('[START] '.yellow + 'Open home page');
  open('http://localhost:' + app.get('port'));
  console.log('[END] '.green + 'Open home page');
  console.log('[END] '.green + 'Break Time start-up');
});
