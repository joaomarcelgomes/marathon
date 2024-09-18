import { test, expect } from 'vitest'
import api from '../src/lib/axios/config'

test('Should return all created competitions', async () => {
  const response = await api.get('/competition/1/user')
  expect(response.status).toBe(200)
  expect(response.data.success).toEqual(true)
})
