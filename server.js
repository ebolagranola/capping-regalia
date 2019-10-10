var express = require('express');
var app = express();
var path = require('path');

// viewed at http://localhost:8080
app.get('/', function(req, res) {
    res.sendFile(path.join(__dirname + '/index.html'));
});

app.get('/wireframe.png', function(req, res) {
    res.sendFile(path.join(__dirname + '/wireframe.png'));
});

app.listen(1000);
