import { test, expect } from 'vitest'
import api from '../src/lib/axios/config'
import user from './mocks/entities/user'

test('Should create a user', async () => {
  const data = { ...user, password: '12345678' }
  const response = await api.post('/user', data)
  expect(response.status).toBe(200)
  expect(response.data.success).toEqual(true)
  expect(response.data.message).toBeTypeOf('string')
  expect(response.data.data.token).toBeTypeOf('string')
  expect(response.data.data.user).toEqual(user)
})
