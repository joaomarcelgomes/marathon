import { useState } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import useAuth from '@/hooks/use-auth'
import InputIcon from '@/components/InputIcon'
import Icon from '@/components/Icon'
import zod from 'zod'

const schema = zod
  .object({
    name: zod.string(),
    email: zod.string().email('E-mail inválido.'),
    password: zod.string().min(8, 'Senha deve ter no mínimo 8 caracteres.'),
    confirmPassword: zod.string(),
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: 'Confirmar senha deve ser igual a senha.',
    path: ['confirmPassword'],
  })

export function Register() {
  const { register } = useAuth()
  const navigate = useNavigate()
  const [name, setName] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [confirmPassword, setConfirmPassword] = useState('')
  const [error, setError] = useState('')

  const login = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault()

    const form = {
      name,
      email,
      password,
      confirmPassword,
    }

    try {
      schema.parse(form)
      await register(name, email, password)
      navigate('/')
    } catch (error) {
      if (error instanceof zod.ZodError) {
        setError(error.errors[0].message)
      } else {
        setError('E-mail e/ou senha inválidos.')
      }
    }
  }

  return (
    <main className="container">
      <div className="wrapper">
        <Link to="/">
          <img
            src="/marathon-logo.svg"
            alt="Logo Marathon"
            className="mt-3 mb-5"
            width={75}
            height={75}
          />
        </Link>
        <form onSubmit={login} className="d-flex gap-4 flex-column mb-3">
          <InputIcon
            type="text"
            placeholder="Nome completo"
            onChange={(e) => setName(e.target.value)}
            value={name}
            icon={<Icon.Person />}
            required
          />
          <InputIcon
            type="email"
            placeholder="E-mail"
            onChange={(e) => setEmail(e.target.value)}
            value={email}
            icon={<Icon.Email />}
            required
          />
          <InputIcon
            type="password"
            placeholder="Senha"
            onChange={(e) => setPassword(e.target.value)}
            value={password}
            icon={<Icon.Lock />}
            required
          />
          <InputIcon
            type="password"
            placeholder="Confirmar senha"
            onChange={(e) => setConfirmPassword(e.target.value)}
            value={confirmPassword}
            icon={<Icon.Lock />}
            required
          />
          {error && (
            <div className="alert alert-danger mb-0" role="alert">
              {error}
            </div>
          )}
          <input className="btn btn-primary" type="submit" value="Cadastrar" />
          <p>
            Já possui uma conta?{' '}
            <Link to="/login" className="color-primary">
              Entrar
            </Link>
          </p>
        </form>
      </div>
    </main>
  )
}
