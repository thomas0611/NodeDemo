var http = require('http');
module.exports = function () {
    return {
        getData: function (url, callbackFunction) {
            var body = '';
            // 处理响应的回调函数
            var callback = function (response) {
                response.setEncoding('utf8');
                // 不断更新数据
                response.on('data', function (data) {
                    body += data;
                });
                response.on('end', function () {
                    // 数据接收完成
                    callbackFunction(body);
                });
            }
            var req = http.request(url, callback);
            req.end();
        },
        getData2:async function (url) {
            var body = '';
            // 处理响应的回调函数
            var callback = function (response) {
                // 不断更新数据
                response.on('data', function (data) {
                    body += data;
                });
                response.on('end', function () {
                    // 数据接收完成
                    callbackFunction(body);
                });
            }
            var req = http.request(url, callback);
            req.end();
        },
    };
}()