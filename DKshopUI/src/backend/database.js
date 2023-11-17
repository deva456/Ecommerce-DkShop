const { Client } = require('pg')

module.exports = new Client({

host: "localhost",

user: "postgres",

port: 5432,

password: "root",

database: "amshop"

})
