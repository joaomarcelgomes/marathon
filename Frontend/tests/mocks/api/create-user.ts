import session from '../data/session'
import response from '../helpers/response'

export default {
  ...response,
  message: 'Usuário criado com sucesso',
  data: session,
}
