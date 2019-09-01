module.exports = {
  env: {
    browser: true,
    es6: true
  },
  extends: [],
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
  plugins: ["@typescript-eslint", "react"],
  rules: {
    "indent": ["error", 4]
  }
}
