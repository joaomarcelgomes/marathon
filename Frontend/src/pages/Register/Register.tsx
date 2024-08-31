import { useState } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import Icon from '@/components/Icon'
import Input from '@/components/Input'
import useAuth from '@/hooks/use-auth'
import schema from '@/lib/zod/register-schema'
import zod from 'zod'

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

    try {
      schema.parse({ name, email, password, confirmPassword })
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
    <main className="container min-vh-100">
      <div className="wrapper text-center">
        <Link to="/">
          <img
            src="/marathon-logo.svg"
            alt="Logo Marathon"
            className="mt-3 mb-5"
            width={75}
            height={75}
          />
        </Link>
        <form
          onSubmit={login}
          className="d-flex gap-4 flex-column mb-3"
          spellCheck="false"
        >
          <Input
            type="text"
            value={name}
            placeholder="Nome completo"
            onChange={(e) => setName(e.target.value)}
            icon={<Icon.Person />}
            required
          />
          <Input
            type="email"
            value={email}
            placeholder="E-mail"
            onChange={(e) => setEmail(e.target.value)}
            icon={<Icon.Email />}
            required
          />
          <Input
            type="password"
            value={password}
            placeholder="Senha"
            onChange={(e) => setPassword(e.target.value)}
            icon={<Icon.Lock />}
            required
          />
          <Input
            type="password"
            value={confirmPassword}
            placeholder="Confirmar senha"
            onChange={(e) => setConfirmPassword(e.target.value)}
            icon={<Icon.Lock />}
            required
          />
          {error && (
            <div className="alert alert-danger mb-0" role="alert">
              {error}
            </div>
          )}
          <input
            type="submit"
            className="btn btn-primary mt-2"
            value="Cadastrar"
          />
          <p>
            Já possui uma conta?{' '}
            <Link to="/login" className="primary">
              Entrar
            </Link>
          </p>
        </form>
      </div>
    </main>
  )
}
