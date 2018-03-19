var express = require('express');
var router = express.Router();
var fs = require("fs");
var path = require("path");
var cheerio = require('cheerio');
var mustache = require("../lib/mustache");
var tableBll = require("../services/tableBll");
var httpHelper = require('../services/httpHelper');
var rootPath = path.resolve(__dirname, '../');//web root path
// 该路由使用的中间件
/* router.use(function timeLog(req, res, next) {
  console.log('Time: ', Date.now());
  next();
}); */
// 定义列表页的路由
router.get('/', async function (req, res) {
    fs.readFile(rootPath + "/views/index.html", 'utf8', function (err, tpl) {
        res.send(tpl);
    });
});
//API
router.get('/TableList', async function (req, res) {
    var list = await tableBll.getTableList();
    var index = 1;
    fs.readFile(rootPath + "/views/tableList.html", 'utf8', function (err, tpl) {
        var data = {
            TableList: list, IndexStr: function () {
                return index++;
            }
        };
        res.send(mustache.render(tpl, data));
    });
});
// 定义API的路由
router.get('/GetTableList', async function (req, res) {
    var list = await tableBll.getTableList();
    res.end(JSON.stringify({ data: list }, null, 2));
});
// 定义Edit页面的路由
router.get('/TableView/:name', async function (req, res) {
    var list = await tableBll.getTableByName(req.params.name);
    fs.readFile(rootPath + "/views/tableView.html", 'utf8', function (err, tpl) {
        var data = { ColumnList: list };
        res.send(mustache.render(tpl, data));
    });
});
// 定义API的路由
router.get('/GetTableByName/:name', async function (req, res) {
    var list = await tableBll.getTableByName(req.params.name);
    res.end(JSON.stringify({ data: list }, null, 2));
});
// 定义web请求的路由
router.get('/Webcontent', async function (req, res) {
    httpHelper.getData('http://cnodejs.org/topic/5203a71844e76d216a727d2e', function (data) {
        res.send(data);
    });
});
router.get('/Cheerio', function (req, res) {
    /*
    ///获取dom的text()时不会因为网页gzip压缩导致中文出现的乱码，获取html()时会出现；
    ///https://segmentfault.com/q/1010000003500477
    ///https://segmentfault.com/q/1010000007540588
    var Entities = require('html-entities').XmlEntities;
    entities = new Entities();
    var str = '<p>&#x867D;&#x7136;&#x53EF;&#x4EE5;&#x5728;&#x7F51;&#x4E0A;&#x641C;</p>';
    console.log(entities.decode(str));
    */
    httpHelper.getData('http://www.cnblogs.com/cate/csharp/', function (data) {
        var $ = cheerio.load(data);
        var list = [];
        $(".post_item").each(function (index, item) {
            // this === item
            var tar = $(this).find(".titlelnk");
            list.push(
                {
                    title: tar.text(),
                    url: tar.attr("href"),
                    diggnum: $(item).find(".diggnum").text()
                });
        });
        res.end(JSON.stringify({ data: list }, null, 2));
    });
});
router.get('/monaco', async function (req, res) {
    fs.readFile(rootPath + "/views/monacoDemo.html", 'utf8', function (err, tpl) {
        res.send(tpl);
    });
});
router.get('/monacocode', async function (req, res) {
    fs.readFile(rootPath + "/controller/indexController.js", 'utf8', function (err, tpl) {
        res.send(tpl);
    });
});
module.exports = router;