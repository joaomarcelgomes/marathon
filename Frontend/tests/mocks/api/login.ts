import success from '../messages/success'
import session from '../data/session'

export default {
  ...success,
  message: 'Usuário logado com sucesso',
  data: session,
}
