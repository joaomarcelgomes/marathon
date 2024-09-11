import config from '@/lib/axios/config'
import type { Response, Session, User } from 'auth'

export async function login(email: string, password: string) {
  const data = { email, password }
  return await config.post<Response<Session>>('/user/login', data)
}

export async function register(name: string, email: string, password: string) {
  const data = { name, email, password }
  return await config.post<Response<Session>>('/user', data)
}

export async function me(id: number) {
  return await config.get<Response<User>>('/user/' + id)
}

export async function update(
  id: number,
  name: string,
  email: string,
  password: string
) {
  const data = { name, email } as {
    name: string
    email: string
    password: string
  }

  if (password) {
    data.password = password
  }

  return await config.put<Response<void>>('/user/' + id, data)
}

export async function remove(id: number) {
  return await config.delete('/user/' + id)
}
