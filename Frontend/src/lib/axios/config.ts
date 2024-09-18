import axios from 'axios'
// import type { AxiosRequestConfig } from 'axios'
// import MockAdapter from 'axios-mock-adapter'
import * as cookies from '@/utils/cookies'
// import success from '@/tests/mocks/messages/success'
// // import login from '@/tests/mocks/api/login'
// import me from '@/tests/mocks/api/current-user'
// import createUser from '@/tests/mocks/api/create-user'
// import competitions from '@/tests/mocks/api/get-competitions'
// import teams from '@/tests/mocks/api/get-teams'
// import users from '@/tests/mocks/api/get-users'

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

// const mock = new MockAdapter(config)

// const auth = (config: AxiosRequestConfig, response: unknown) => {
//   if (!config.headers.Authorization.startsWith('Bearer '))
//     return [401, { message: 'Unauthorized' }]

//   return [200, response]
// }

// mock.onGet('/user/all').reply((config) => auth(config, users))
// mock.onPost('/user/create').reply(200, createUser)
// mock.onGet('/user/profile').reply((config) => auth(config, me))
// // mock.onPost('/user/login').reply(200, login)
// mock.onPut('/user').reply((config) => auth(config, success))
// mock.onDelete('/user/1').reply((config) => auth(config, success))

// mock.onGet('/competition/1').reply((config) => auth(config, competitions))
// mock.onPost('/competition/1/teams').reply((config) => auth(config, success))

// mock.onGet('/team/all').reply((config) => auth(config, teams))
// mock.onPost('/team/create').reply((config) => auth(config, success))

export default config
