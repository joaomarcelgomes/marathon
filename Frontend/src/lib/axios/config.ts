import axios from 'axios'
import type { AxiosRequestConfig } from 'axios'
import * as cookies from '@/utils/cookies'
import MockAdapter from 'axios-mock-adapter'
import login from '@/mocks/login'
import register from '@/mocks/register'
import user from '@/mocks/current-user'

const config = axios.create({
  baseURL: 'http://localhost:5000',
})

config.interceptors.request.use(
  (config) => {
    const token = cookies.getSession()
    config.headers.Authorization = 'Bearer ' + token
    return config
  },
  (error) => {
    return Promise.reject(error)
  }
)

const mock = new MockAdapter(config)

const auth = (config: AxiosRequestConfig, response: unknown) => {
  if (config.headers?.Authorization.startsWith('Bearer ')) {
    return [200, response]
  } else {
    return [401, { message: 'Unauthorized' }]
  }
}

mock.onPost('/login').reply(200, login)
mock.onPost('/register').reply(200, register)
mock.onGet('/user').reply((config) => auth(config, user))

export default config
