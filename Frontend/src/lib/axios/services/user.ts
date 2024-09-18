import config from '@/lib/axios/config'

export async function all() {
  return config.get<GetUsersResponse>('/user/all')
}

export async function create(data: CreateUserRequest) {
  return config.post<CreateUserResponse>('/user/create', data)
}

export async function update(data: UpdateUserRequest) {
  return config
    .put<UpdateUserResponse>('/user', data)
    .catch((err) => console.log(err))
}

export async function remove(id: number) {
  return config.delete<DeleteUserResponse>('/user/' + id)
}

export async function login(data: LoginRequest) {
  return config.post<LoginResponse>('/user/login', data)
}

export async function me() {
  return config.get<GetMeResponse>('/user/profile')
}
