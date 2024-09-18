import config from '@/lib/axios/config'

export async function all() {
  return config.get<GetTeamsResponse>('/team/all')
}

export async function create(data: CreateTeamRequest) {
  return config.post<CreateTeamResponse>('/team/create', data)
}

export async function remove(id: number) {
  return config.delete('/team/remove/' + id)
}
