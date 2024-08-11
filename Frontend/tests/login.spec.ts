import { test, expect } from 'vitest'
import api from '../src/lib/axios/config'

test('Should return token JWT and user', async () => {
  const data = {
    email: 'johndoe@mock.com',
    password: 'passmock123',
  }

  const response = await api.post('/login', data)
  expect(response.status).toBe(200)
  expect(response.data.success).toEqual(true)
  expect(response.data.message).toBeTypeOf('string')
  expect(response.data.data.token).toBeTypeOf('string')
  expect(response.data.data.user).toHaveProperty('id')
  expect(response.data.data.user).toHaveProperty('name')
  expect(response.data.data.user.email).toEqual(data.email)
  expect(response.data.data.user).toHaveProperty('avatar')
})
