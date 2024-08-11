import js from '@eslint/js'
import globals from 'globals'
import reactHooks from 'eslint-plugin-react-hooks'
import reactRefresh from 'eslint-plugin-react-refresh'
import tseslint from 'typescript-eslint'
import prettier from 'eslint-plugin-prettier'

export default tseslint.config({
  extends: [js.configs.recommended, ...tseslint.configs.recommended],
  files: ['**/*.{ts,tsx}'],
  ignores: ['dist'],
  languageOptions: {
    ecmaVersion: 2020,
    globals: globals.browser,
  },
  plugins: {
    'prettier': prettier,
    'react-hooks': reactHooks,
    'react-refresh': reactRefresh,
  },
  rules: {
    'prettier/prettier': ['error', {
      "semi": false,
      "singleQuote": true,
      "trailingComma": "es5",
      "tabWidth": 2,
      "printWidth": 80
    }],
    ...reactHooks.configs.recommended.rules,
    'react-refresh/only-export-components': [
      'warn',
      { allowConstantExport: true },
    ],
  },
})
