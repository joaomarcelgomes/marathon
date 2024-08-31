import { test, expect } from 'vitest'
import api from '../src/lib/axios/config'

test('Should remove a user', async () => {
  const response = await api.delete('/user/1')
  expect(response.status).toBe(200)
  expect(response.data.success).toEqual(true)
})
