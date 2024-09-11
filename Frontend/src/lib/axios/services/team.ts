import config from '@/lib/axios/config'
import type { Response, Team } from 'auth'

export async function all(id: number) {
  return await config.get<Response<Team[]>>('/team/' + id)
}
