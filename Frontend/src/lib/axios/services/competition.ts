import config from '@/lib/axios/config'

export async function all(id: number) {
  return config.get<GetCompetitionsResponse>('/competition/' + id)
}

export async function create(data: CreateCompetitionRequest) {
  return config.post<CreateCompetitionResponse>('/competition', data)
}
