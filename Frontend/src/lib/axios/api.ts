import axios from 'axios'
import MockAdapter from 'axios-mock-adapter'
import users from '@/mocks/users'
import user from '@/mocks/user'

const api = axios.create({
  baseURL: 'http://localhost:5000',
})

const mock = new MockAdapter(api)

mock.onGet('/user').reply(200, users)
mock.onPost('/user').reply(201, user)
mock.onPost('/login').reply(200, user)
mock.onPost('/register').reply(200, user)

export default api
