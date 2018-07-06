const API_URL = 'http://localhost:40004'

const PROXY_CONFIG = [
  {
    context: [
      '/api/*'
    ],
    target: API_URL,
    secure: false
  }
]

module.exports = PROXY_CONFIG;