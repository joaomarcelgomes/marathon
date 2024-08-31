import axios from 'axios'
import type { AxiosRequestConfig } from 'axios'
import MockAdapter from 'axios-mock-adapter'
import * as cookies from '@/utils/cookies'
import login from '@/tests/mocks/login'
import createUser from '@/tests/mocks/create-user'
import updateUser from '@/tests/mocks/update-user'
import removeUser from '@/tests/mocks/remove-user'
import user from '@/tests/mocks/current-user'

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

mock.onPost('/user/login').reply(200, login)
mock.onPost('/user').reply(200, createUser)
mock.onGet('/user').reply((config) => auth(config, user))
mock.onPut('/user').reply(200, updateUser)
mock.onDelete('/user/1').reply(200, removeUser)

export default config
