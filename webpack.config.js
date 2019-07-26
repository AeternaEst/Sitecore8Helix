const path = require('path');

module.exports = {
  mode: 'development',
  entry: './Src/Frontend/index.jsx',
  devtool: "source-map",
  module: {
    rules: [
      {
        test: /\.(t|j)sx?$/,
        exclude: /node_modules/,
        use: { loader: 'awesome-typescript-loader' }
      }
    ]
  },
  resolve: {
    extensions: ['.ts', '.tsx', '.js', '.jsx']
  },
  output: {
    path: __dirname + '/Website/dist/js/',
    publicPath: '/',
    filename: 'bundle.js'
  }
};