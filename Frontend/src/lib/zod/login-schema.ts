import zod from 'zod'

export default zod.object({
  email: zod.string().email('E-mail inválido.'),
  password: zod.string().min(8, 'Usuário inválido.'),
})
