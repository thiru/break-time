console.log('Starting Break Time...');

process.stdout.write('Loading dependencies... ');
var express = require('express');
var http = require('http');
var path = require('path');
var open = require('open');
console.log('done.');

process.stdout.write('Configuring Express... ');
var defaultPort = 8080;
var app = express();

app.set('port', process.env.PORT || defaultPort);
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'ejs');
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
console.log('done.');

http.createServer(app).listen(app.get('port'), function() {
  console.log('Break Time\'s web server started and listening on port ' + app.get('port') + '.');
  process.stdout.write('Opening home page... ');
  open('http://localhost:' + app.get('port'));
  console.log('done');
});

