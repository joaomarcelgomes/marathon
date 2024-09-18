import { test, expect } from 'vitest'
import api from '../src/lib/axios/config'

test('Should return all users', async () => {
  const response = await api.get('/user/all')
  expect(response.status).toBe(200)
  expect(response.data.success).toEqual(true)
})
