import { test, expect } from 'vitest'
import api from '../src/lib/axios/api'
import user from '../src/mocks/user'

test('Should return the registered user', async () => {
  const response = await api.post('/login', user)
  expect(response.status).toBe(200)
  expect(response.data).toEqual(user)
})
