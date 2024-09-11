import session from '../data/session'
import response from '../helpers/response'

export default {
  ...response,
  message: 'Usuário logado com sucesso',
  data: session,
}
