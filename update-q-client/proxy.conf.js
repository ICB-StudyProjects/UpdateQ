const API_URL = 'https://localhost:40004'

const PROXY_CONFIG = [
  {
    context: [
      '/api/*'
    ],
    target: API_URL,
    secure: true
  }
]

module.exports = PROXY_CONFIG;