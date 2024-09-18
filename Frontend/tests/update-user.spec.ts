import { test, expect } from 'vitest'
import api from '../src/lib/axios/config'
import user from './mocks/entities/user'

test('Should update a user', async () => {
  const data = { ...user, email: 'test@example.com' }
  const response = await api.put('/user', data)
  expect(response.status).toBe(200)
  expect(response.data.success).toEqual(true)
})
