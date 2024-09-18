declare global {
  interface Response<T> {
    success: boolean
    message: string
    data: T
  }

  interface User {
    id: number
    name: string
    email: string
    avatar: string | undefined
    teams: Team[]
    competitions: Competition[]
  }

  interface Team {
    id: number
    name: string
    imageUrl: string
    users: User[]
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

  interface Session {
    token: string
    user: User
  }

  /* Users */
  type GetUsersResponse = Response<User[]>
  type GetMeResponse = Response<User>

  type CreateUserRequest = {
    password: string
  } & Omit<User, 'id', 'teams', 'competitions'>
  type CreateUserResponse = Response<Session>

  type UpdateUserRequest = Partial<User>
  type UpdateUserResponse = Response<void>

  type DeleteUserResponse = Response<void>

  /* Teams */
  type GetTeamsResponse = Response<Team[]>

  type CreateTeamRequest = {
    usersIds: number[]
  } & Omit<Team, 'id' | 'users' | 'createdAt'>
  type CreateTeamResponse = Response<void>

  /* Competitions */
  type GetCompetitionsResponse = {
    competitions: Competition[]
  } & Omit<Response, 'data'>

  type CreateCompetitionRequest = {
    userId: number
    teamsIds: number[]
  } & Omit<Competition, 'id' | 'teams'>
  type CreateCompetitionResponse = Response<void>

  /* Authentication */
  type LoginRequest = {
    email: string
    password: string
  }
  type LoginResponse = Response<Session>
}

export {}
