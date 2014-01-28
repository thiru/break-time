console.log('App started.');

var open = require('open');
var connect = require('connect');

var port = 8080;
var app = connect()
            .use(connect.logger('dev'))
            .use(connect.favicon(__dirname + '/ui/images/favicon.ico'))
            .use(connect.static('ui'))
            .use(connect.errorHandler()) // Only use for dev/testing
            .listen(port);

open('http://localhost:' + port);
