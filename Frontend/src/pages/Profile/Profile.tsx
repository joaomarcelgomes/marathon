import { ChangeEvent, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import Input from '@/components/Input'
import useAuth from '@/hooks/use-auth'
import HomeLayout from '@/layouts/Home'
import Avatar from '@/components/Avatar'
import schema from '@/lib/zod/update-user-schema'
import zod from 'zod'

export function Profile() {
  const navigate = useNavigate()
  const { user, updateUser, removeUser } = useAuth()
  const [error, setError] = useState('')
  const [form, setForm] = useState({
    name: user.name,
    email: user.email,
    password: '',
  })

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value })
  }

  const update = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault()

    try {
      schema.parse(form)
      await updateUser(form)
      setError('')
    } catch (error) {
      if (error instanceof zod.ZodError) {
        setError(error.errors[0].message)
      } else {
        setError('Ocorreu um erro. Tente novamente mais tarde.')
      }
    }
  }

  const remove = async () => {
    try {
      await removeUser()
      navigate('/login')
    } catch {
      setError('Ocorreu um erro. Tente novamente mais tarde.')
    }
  }

  return (
    <HomeLayout>
      <section className="container h-100 mt-3">
        <div className="p-8 mx-auto">
          <div className="d-flex flex-column align-items-center gap-3 mb-2">
            <Avatar url={user.avatar} width={120} height={120} />
            <h3>{user.name}</h3>
          </div>
          <form
            onSubmit={update}
            className="d-flex gap-4 flex-column"
            autoComplete="off"
            spellCheck="false"
          >
            <div className="form-group">
              <label htmlFor="name">Nome</label>
              <Input
                id="name"
                name="name"
                value={form.name}
                className="shadow-sm"
                onChange={handleChange}
              />
            </div>
            <div className="form-group">
              <label htmlFor="email">Email</label>
              <Input
                id="email"
                type="email"
                name="email"
                value={form.email}
                className="shadow-sm"
                onChange={handleChange}
              />
            </div>
            <div className="form-group">
              <label htmlFor="password">Nova senha</label>
              <Input
                id="password"
                type="password"
                name="password"
                value={form.password}
                className="shadow-sm"
                onChange={handleChange}
              />
            </div>
            {error && (
              <div className="alert alert-danger mb-0" role="alert">
                {error}
              </div>
            )}
            <input
              type="submit"
              className="btn btn-primary mt-4"
              value="Salvar"
            />
          </form>
          <button className="btn text-underline mt-4 mx-auto" onClick={remove}>
            Excluir conta
          </button>
        </div>
      </section>
    </HomeLayout>
  )
}
