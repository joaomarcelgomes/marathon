import { test, expect } from 'vitest'
import user from '../src/mocks/user'
import api from '../src/lib/axios/config'

test('Should return token JWT and user', async () => {
  const data = {
    ...user,
    password: '12345678',
  }

  const response = await api.post('/register', data)
  expect(response.status).toBe(200)
  expect(response.data.success).toEqual(true)
  expect(response.data.message).toBeTypeOf('string')
  expect(response.data.data.token).toBeTypeOf('string')
  expect(response.data.data.user).toEqual(user)
})
