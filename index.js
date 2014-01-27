var path = require('path');
var open = require('open');

console.log('App started.');

var homePage = path.join(process.cwd(), '/ui/index.html');
open('file://' + homePage);

console.log('App exited.');
