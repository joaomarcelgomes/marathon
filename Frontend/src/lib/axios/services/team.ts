import config from '@/lib/axios/config'

export async function all() {
  return config.get<GetTeamsResponse>('/team/all')
}

export async function create(data: CreateTeamRequest) {
  return config.post<CreateTeamResponse>('/team/create', data)
}
