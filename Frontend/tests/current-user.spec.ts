import { test, expect } from 'vitest'
import api from '../src/lib/axios/config'
import user from './mocks/entities/user'

test('Should return the authenticated user', async () => {
  const response = await api.get('/user/1')
  expect(response.status).toBe(200)
  expect(response.data.success).toEqual(true)
  expect(response.data.data).toEqual(user)
})
