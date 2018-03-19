var express = require('express');
var app = express();
var fs = require("fs");
var classCtrl = require('./controller/classController');
var indexCtrl = require('./controller/indexController');
//var mustache = require("./lib/mustache");
//content设置为静态文件根目录，/content/css/docs.css的路径变成为../css/docs.css
app.use(express.static('content'));
app.use('/', indexCtrl);
app.use('/Class', classCtrl);
//错误处理
app.use(function (err, req, res, next) {
  //console.error(err.stack);
  //res.send({ error: err });
  console.log({ error: err })
});
/* app.get('/', async function (req, res) {
  var list = await tableBll.getTableList();
  //res.send({data:list});
  var index = 1;
    fs.readFile(__dirname + "/views/tableList.html", 'utf8', function (err, tpl) {
        var data = { TableList: list,IndexStr :function(){
          return index++;
        } };
        res.send(mustache.render(tpl, data));
    });
}) */
//  POST 请求
app.post('/', function (req, res) {
  res.send('Hello POST');
})
//  /list_user 页面 GET 请求
app.get('/listUsers', function (req, res) {
  fs.readFile(__dirname + "/" + "users.json", 'utf8', function (err, data) {
    res.send(data);
  });
})
// 对页面 abcd, abxcd, ab123cd, 等响应 GET 请求
app.get('/ab*cd', function (req, res) {
  console.log("/ab*cd GET 请求");
  res.send('正则匹配');
})


var server = app.listen(8088, function () {
  var host = server.address().address
  var port = server.address().port
  console.log("应用实例，访问地址为 http://localhost:%s", port)
})