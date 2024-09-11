declare module 'auth' {
  interface Team {
    id: number
    name: string
    imageUrl: string
    members: User[]
    shortName: string
    createdAt: string
  }

  interface Competition {
    id: number
    name: string
    description: string
    prize: string
    teams: Team[]
    start: string
    end: string
  }

  interface User {
    id: number
    name: string
    email: string
    avatar: string | undefined
    teams: Team[]
    competitions: Competition[]
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
