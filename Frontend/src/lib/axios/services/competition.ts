import config from '@/lib/axios/config'
import type { Response, Competitions } from 'auth'

export async function all(id: number) {
  return await config.get<Response<Competitions[]>>('/competition/' + id)
}
