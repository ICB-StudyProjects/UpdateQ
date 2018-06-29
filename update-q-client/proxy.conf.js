const API_URL = 'http://localhost:50253'

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