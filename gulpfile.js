const { series, parallel } = require('gulp');
const webpack = require("webpack");
var webpackConfig = require("./webpack.config.js");
var exec = require('child_process').exec;

function build(cb) {
  exec('npx webpack', function (err, stdout, stderr) {
    console.log(stdout);
    console.log(stderr);
    cb(err);
  });
}

function runWebpack(cb) {
  webpack(webpackConfig, (err, stats) => {
    if (err) {
        throw new Exception(err);
    }
    if (stats.hasErrors()) {
      throw new Exception(stats.compilation.errors);
    }
    console.log(stats.toString());
    cb();
  })
}

exports.default = series(runWebpack);