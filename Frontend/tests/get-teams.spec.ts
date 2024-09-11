import { test, expect } from 'vitest'
import api from '../src/lib/axios/config'

test('Should return all user teams', async () => {
  const response = await api.get('/team/1')
  expect(response.status).toBe(200)
  expect(response.data.success).toEqual(true)
})
