import { useState } from 'react'
import { Link } from 'react-router-dom'
import Icon from '@/components/Icon'
import Input from '@/components/Input'
import useAuth from '@/hooks/use-auth'
import schema from '@/lib/zod/register-schema'
import avatar from '@/utils/avatar-url'
import zod from 'zod'

export function Register() {
  const { register } = useAuth()
  const [confirmPassword, setConfirmPassword] = useState('')
  const [error, setError] = useState('')
  const [form, setForm] = useState({
    name: '',
    email: '',
    password: '',
  })

  const login = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault()

    try {
      schema.parse({ ...form, confirmPassword })
      await register({ ...form, avatar: avatar(form.name) })
      window.location.href = '/'
    } catch (error) {
      if (error instanceof zod.ZodError) {
        setError(error.errors[0].message)
      } else {
        console.log(error)
        setError('Ocorreu um erro. Tente mais tarde.')
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
            name="name"
            placeholder="Nome completo"
            onChange={handleChange}
            icon={<Icon.Person />}
            required
          />
          <Input
            type="email"
            name="email"
            placeholder="E-mail"
            onChange={handleChange}
            icon={<Icon.Email />}
            required
          />
          <Input
            type="password"
            name="password"
            placeholder="Senha"
            onChange={handleChange}
            icon={<Icon.Lock />}
            required
          />
          <Input
            type="password"
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
