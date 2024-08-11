import config from '@/lib/axios/config'
import type { Session, User, Response } from 'auth'

export async function login(email: string, password: string) {
  const data = {
    email,
    password,
  }

  return await config.post<Response<Session>>('/login', data)
}

export async function register(name: string, email: string, password: string) {
  const data = {
    name,
    email,
    password,
  }

  return await config.post<Response<Session>>('/register', data)
}

export async function me() {
  return await config.get<Response<User>>('/user')
}
