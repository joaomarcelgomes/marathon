import zod from 'zod'

export default zod
  .object({
    name: zod.string().min(1, 'O nome é obrigatório.'),
    email: zod.string().email('E-mail inválido.'),
    password: zod.string().min(8, 'Senha com mínimo de 8 caracteres.'),
    confirmPassword: zod.string(),
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: 'Confirmar senha deve ser igual a senha.',
    path: ['confirmPassword'],
  })
