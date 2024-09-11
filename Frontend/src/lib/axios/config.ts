import axios from 'axios'
import type { AxiosRequestConfig } from 'axios'
import MockAdapter from 'axios-mock-adapter'
import * as cookies from '@/utils/cookies'
import login from '@/tests/mocks/api/login'
import createUser from '@/tests/mocks/api/create-user'
import updateUser from '@/tests/mocks/api/update-user'
import removeUser from '@/tests/mocks/api/remove-user'
import me from '@/tests/mocks/api/current-user'
import competitions from '@/tests/mocks/api/get-competitions'
import teams from '@/tests/mocks/api/get-teams'

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
  if (!config.headers.Authorization.startsWith('Bearer '))
    return [401, { message: 'Unauthorized' }]

  return [200, response]
}

mock.onPost('/user/login').reply(200, login)
mock.onPost('/user').reply(200, createUser)
mock.onGet('/user/1').reply((config) => auth(config, me))
mock.onPut('/user/1').reply(200, updateUser)
mock.onDelete('/user/1').reply(200, removeUser)
mock.onGet('/competition/1').reply((config) => auth(config, competitions))
mock.onGet('/team/1').reply((config) => auth(config, teams))

export default config
