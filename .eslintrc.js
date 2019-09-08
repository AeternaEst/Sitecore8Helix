module.exports = {
  env: {
    browser: true,
    es6: true
  },
  extends: ['eslint:recommended', 'plugin:react/recommended', 'plugin:@typescript-eslint/recommended', 'plugin:prettier/recommended'],
  globals: {
    Atomics: 'readonly',
    SharedArrayBuffer: 'readonly'
  },
  parserOptions: {
    ecmaFeatures: {
      jsx: true
    },
    ecmaVersion: 2018,
    sourceType: 'module'
  },
  parser: "@typescript-eslint/parser",
  plugins: ["@typescript-eslint", "react", "prettier"],
  rules: {
    "no-redeclare": "warn",
    "@typescript-eslint/explicit-function-return-type": ["off", {
        // if true, only functions which are part of a declaration will be checked
        allowExpressions: true,
        // if true, type annotations are also allowed on the variable of a function expression rather than on the function directly
        allowTypedFunctionExpressions: true,
        // if true, functions immediately returning another function expression will not be checked
        allowHigherOrderFunctions: true
      }
    ],
    "prettier/prettier": "error"
  }
}
