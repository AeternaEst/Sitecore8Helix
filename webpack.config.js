const path = require('path');

module.exports = {
  mode: 'development',
  entry: './Src/Frontend/index.jsx',
  module: {
    rules: [
      {
        test: /\.(js|jsx)$/,
        exclude: /node_modules/,
        use: ['babel-loader']
      }
    ]
  },
  resolve: {
    extensions: ['*', '.js', '.jsx']
  },
  output: {
    path: __dirname + '/Website/dist/js/',
    publicPath: '/',
    filename: 'bundle.js'
  }
};