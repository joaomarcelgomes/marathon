import success from '../messages/success'
import user from '../entities/user'
import teams from '../data/teams'

export default {
  ...success,
  data: teams.map((team) => ({ ...team, members: team.members.concat(user) })),
}
