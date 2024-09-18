import { useState } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import Icon from '@/components/Icon'
import Input from '@/components/Input'
import useAuth from '@/hooks/use-auth'
import schema from '@/lib/zod/login-schema'
import zod from 'zod'

export function Login() {
  const { signin } = useAuth()
  const navigate = useNavigate()
  const [error, setError] = useState('')
  const [form, setForm] = useState({
    email: '',
    password: '',
  })

  const login = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()

    try {
      schema.parse(form)
      await signin(form)
      navigate('/')
    } catch (error) {
      if (error instanceof zod.ZodError) {
        setError(error.errors[0].message)
      } else {
        setError('E-mail e/ou senha inválidos.')
      }
    }
  }

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value })
  }

  return (
    <main className="container min-vh-100">
      <div className="p-8 mx-auto text-center">
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
            type="email"
            name="email"
            placeholder="Informe seu e-mail"
            onChange={handleChange}
            icon={<Icon.Email />}
            required
          />
          <Input
            type="password"
            name="password"
            placeholder="Informe sua senha"
            onChange={handleChange}
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
            value="Entrar"
          />
          <p>
            Ainda não tem uma conta?{' '}
            <Link to="/cadastro" className="primary">
              Cadastre-se
            </Link>
          </p>
        </form>
      </div>
    </main>
  )
}
