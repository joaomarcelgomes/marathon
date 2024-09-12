import response from '../helpers/response'
import user from '../entities/user'
import teams from '../data/teams'

export default {
  ...response,
  data: teams.map((team) => ({ ...team, members: team.members.concat(user) })),
}
