import React, { useState } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import InputIcon from '@/components/InputIcon'
import EmailIcon from '/icons/email.svg'
import LockIcon from '/icons/lock.svg'
import api from '@/lib/axios/api'
import zod from 'zod'

const schema = zod.object({
  email: zod.string().email('E-mail inválido.'),
  password: zod.string().min(8, 'Usuário inválido.'),
})

export function Login() {
  const navigate = useNavigate()
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [error, setError] = useState('')

  const login = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault()

    const form = { email, password }

    try {
      const data = schema.parse(form)
      await api.post('/login', data)
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
            type="email"
            placeholder="Informe seu e-mail"
            onChange={(e) => setEmail(e.target.value)}
            value={email}
            icon={EmailIcon}
            required
          />
          <InputIcon
            type="password"
            placeholder="Informe sua senha"
            onChange={(e) => setPassword(e.target.value)}
            value={password}
            icon={LockIcon}
            required
          />
          {error && (
            <div className="alert alert-danger mb-0" role="alert">
              {error}
            </div>
          )}
          <input className="btn btn-primary" type="submit" value="Entrar" />
          <p>
            Ainda não tem uma conta?{' '}
            <Link to="/cadastro" className="color-primary">
              Cadastre-se
            </Link>
          </p>
        </form>
      </div>
    </main>
  )
}
