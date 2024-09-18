import api from '@/lib/axios/api'
import * as cookies from './cookies'
import { jwtDecode } from 'jwt-decode'

export default async function retrieveUser() {
  try {
    const id = +jwtDecode(cookies.getSession()).sub
    const user = await api.user.me()

    const teams = await api.team.all().catch(() => {
      return { data: { data: [] } }
    })

    const competitions = await api.competition.all(id)

    const data = {
      ...user.data.data,
      teams: teams.data.data,
      competitions: competitions.data.competitions,
    }

    return data
  } catch {
    return null
  }
}
