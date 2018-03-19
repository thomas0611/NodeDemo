var express = require('express');
var router = express.Router();
var fs = require("fs");
var path = require("path");
var mustache = require("../lib/mustache");
var classBll = require("../services/classBll");
var rootPath = path.resolve(__dirname, '../');//web root path
// 该路由使用的中间件
/* router.use(function timeLog(req, res, next) {
  console.log('Time: ', Date.now());
  next();
}); */
// 定义列表页的路由
router.get('/', async function (req, res) {
    var list = await classBll.getClassList();
    fs.readFile(rootPath + "/views/classList.html", 'utf8', function (err, tpl) {
        var data = { ClassList: list };
        res.send(mustache.render(tpl, data));
    });
});
// 定义API的路由
router.get('/GetClassList', async function (req, res) {
    var list = await classBll.getClassList();
    res.end(JSON.stringify({ data: list }, null, 2));
});
// 定义Edit页面的路由
router.get('/Edit/:id', async function (req, res) {
    var list = await classBll.getClassByID(req.params.id);
    fs.readFile(rootPath + "/views/classEdit.html", 'utf8', function (err, tpl) {
        var data = { Entity: list[0] };
        res.send(mustache.render(tpl, data));
    });
});
// 定义API的路由
router.get('/GetClassById/:id', async function (req, res) {
    var list = await classBll.getClassByID(req.params.id);
    res.end(JSON.stringify({ data: list }, null, 2));
});
module.exports = router;