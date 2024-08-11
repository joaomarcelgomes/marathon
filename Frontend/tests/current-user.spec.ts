import { test, expect } from 'vitest'
import user from '../src/mocks/user'
import api from '../src/lib/axios/config'

test('Should return the logged user', async () => {
  const response = await api.get('/user')
  expect(response.status).toBe(200)
  expect(response.data.success).toEqual(true)
  expect(response.data.data).toEqual(user)
})
