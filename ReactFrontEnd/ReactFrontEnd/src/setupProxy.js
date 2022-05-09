const { createProxyMiddleware } = require('http-proxy-middleware');

const context = [
    "/Poll",
    "/Poll/api",
    "/Poll/api/polls",
    "/api/polls",
];

module.exports = function (app) {
    app.use(createProxyMiddleware('/Poll/', { target: 'https://localhost:7027', changeOrigin: true, }));
};