import cookies from 'js-cookie'

const COOKIE_KEY = 'AUTH_TOKEN'
const expires = 4 / 24 // 4 hour

export const get = (key: string) => {
  return cookies.get(key)
}

export const set = (key: string, value: string, options = {}) => {
  cookies.set(key, value, options)
}

export const remove = (key: string) => {
  cookies.remove(key)
}

export const getSession = () => {
  return get(COOKIE_KEY)
}

export const setSession = (token: string) => {
  set(COOKIE_KEY, token, { expires })
}

export const removeSession = () => {
  remove(COOKIE_KEY)
}
