import { test, expect } from 'vitest'
import api from '../src/lib/axios/config'
import user from './mocks/user'

test('Should update a user', async () => {
  const data = { ...user, email: 'test@example.com' }
  const response = await api.put('/user/1', data)
  expect(response.status).toBe(200)
  expect(response.data.success).toEqual(true)
})
