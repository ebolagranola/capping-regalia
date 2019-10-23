var express = require('express');
var app = express();
var path = require('path');

app.use(express.static('./client/'));

// viewed at http://localhost:8080
app.get('/', function(req, res) {
    res.sendFile(path.join(__dirname + '/index.html'));
});

app.get('/wireframe.png', function(req, res) {
    res.sendFile(path.join(__dirname + './client/images/wireframe.png'));
});

app.listen(1000);
