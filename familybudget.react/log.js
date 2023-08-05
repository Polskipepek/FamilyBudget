class Example {
    middleware(config) {
        const morgan = require('koa-morgan');
        return morgan('combined', {
            skip: function (req, res) { return res.statusCode < 400 }
        })
    }
}

module.exports = Example