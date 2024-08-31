import zod from 'zod'

export default zod
  .object({
    name: zod.string().min(1, 'O nome é obrigatório.'),
    email: zod.string().email('E-mail inválido.'),
    password: zod.string().optional(),
  })
  .refine((data) => data.password.length === 0 || data.password.length >= 8, {
    message: 'Senha com mínimo de 8 caracteres.',
    path: ['password'],
  })
