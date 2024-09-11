import response from '../helpers/response'
import user from '../entities/user'
import teams from '../data/teams'

export default {
  ...response,
  data: teams
    .slice(0, 3)
    .map((team) => ({ ...team, members: team.members.concat(user) })),
}
