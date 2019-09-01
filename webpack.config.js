const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const globImporter = require('node-sass-glob-importer');
const CopyPlugin = require('copy-webpack-plugin');

module.exports = {
    mode: 'development',
    entry: './Src/Frontend/index.tsx',
    devtool: "source-map",
    module: {
        rules: [
            {
                test: /\.(t|j)sx?$/,
                exclude: /node_modules/,
                use: ['awesome-typescript-loader', 'eslint-loader']
            },
            {
                test: /\.(sa|sc|c)ss$/,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader
                    },
                    'css-loader', 
                    'postcss-loader', 
                    {
                        loader: 'sass-loader',
                        options: {
                            importer: globImporter()
                        }
                    },
                ],
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
    },
    plugins: [
        new MiniCssExtractPlugin({
      
            filename: '../css/styles.css',
            chunkFilename: '../css/styles.css',
            ignoreOrder: false, // Enable to remove warnings about conflicting order
        }), new CopyPlugin([
            { from: path.resolve(__dirname, 'Src/Frontend/fonts'), to: path.resolve(__dirname, 'Website/dist/fonts') },
            { from: path.resolve(__dirname, 'Src/Frontend/images'), to: path.resolve(__dirname, 'Website/dist/images') }
        ])
    ],
};