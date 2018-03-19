const db = require('mssql');
var config = require('../common/config');
var connection = config.mssqlconnection;
module.exports = function () {
    return {
        getClassList: async function () {
            var pool = await db.connect(connection);
            var result = await pool.request().query('select top 10 * from KH_Class');
            db.close();
            return result.recordset;
        },
        getClassByID: async function (classID) {
            var pool = await db.connect(connection);
            var result = await pool.request().query(`select * from KH_Class where classID ='${classID}' `);
            db.close();
            return result.recordset;
        }
    };
}()