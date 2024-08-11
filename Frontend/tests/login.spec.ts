import { test, expect } from 'vitest'
import api from '../src/lib/axios/api'
import user from '../src/mocks/user'

test('Should return the logged user', async () => {
  const data = {
    email: 'johndoe@mock.com',
    password: 'passmock123',
  }

  const response = await api.post('/login', data)
  expect(response.status).toBe(200)
  expect(response.data).toEqual(user)
})
