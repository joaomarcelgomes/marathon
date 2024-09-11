import api from '@/lib/axios/api'
import * as cookies from './cookies'
import { jwtDecode } from 'jwt-decode'

export default async function retrieveUser() {
  try {
    const id = +jwtDecode(cookies.getSession()).sub
    const user = await api.user.me(id)

    const [teams, competitions] = await Promise.all([
      api.team.all(id),
      api.competition.all(id),
    ])

    const data = {
      ...user.data.data,
      teams: teams.data.data,
      competitions: competitions.data.data,
    }

    return data
  } catch {
    return null
  }
}
