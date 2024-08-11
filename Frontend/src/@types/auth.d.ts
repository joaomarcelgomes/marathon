declare module 'auth' {
  interface User {
    id: number
    name: string
    email: string
    avatar: string | undefined
  }

  interface Session {
    token: string
    user: User
  }

  interface Response<T> {
    success: boolean
    message: string
    data: T
  }
}
