import { test, expect } from 'vitest'
import api from '../src/lib/axios/api'
import users from '../src/mocks/users'

test('Should return all users', async () => {
  const response = await api.get('/user')
  expect(response.status).toBe(200)
  expect(response.data).toEqual(users)
})
