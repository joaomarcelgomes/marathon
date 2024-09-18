import React, { useState } from 'react'
import HomeLayout from '@/layouts/Home'
import Input from '@/components/Input'
import Table from '@/components/Table'
import Checkbox from '@/components/Checkbox'
import api from '@/lib/axios/api'
import avatar from '@/utils/avatar-url'

export function Create() {
  const [users, setUsers] = useState([])
  const [form, setForm] = useState({
    name: '',
    shortName: '',
    usersIds: [],
  })

  const fetchUsers = async () => {
    const response = await api.user.all()
    setUsers(response.data.data)
  }

  React.useEffect(() => {
    fetchUsers()
  }, [])

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    await api.team.create({ ...form, imageUrl: avatar(form.name) })
    window.location.href = '/times'
  }

  const handleCheckboxChange = (id: number) => {
    if (form.usersIds.includes(id)) {
      const usersIds = form.usersIds.filter((memberId) => memberId !== id)
      setForm({ ...form, usersIds })
    } else {
      const usersIds = [...form.usersIds, id]
      setForm({ ...form, usersIds })
    }
  }

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setForm({ ...form, [e.target.name]: e.target.value })
  }

  const Users = () => {
    return users.map((user, i) => (
      <tr key={i}>
        <td align="center">
          <b>{user.id}</b>
        </td>
        <td align="center">
          <img src={user.avatar} width={24} height={24} alt={user.name} />
        </td>
        <td>{user.name}</td>
        <td>{user.email}</td>
        <td align="center">
          <Checkbox
            id={'user_option_' + i}
            checked={form.usersIds.includes(user.id)}
            onChange={() => handleCheckboxChange(user.id)}
          />
        </td>
      </tr>
    ))
  }

  return (
    <HomeLayout>
      <div className="container max-w-lg min-w-sm min-vh-100 px-8 mt-4">
        <form
          onSubmit={handleSubmit}
          className="min-w-sm mx-auto p-8 d-flex flex-column gap-5"
          autoComplete="off"
        >
          <section>
            <h1 className="mb-0">Criar time</h1>
          </section>

          <section className="d-flex flex-row gap-4">
            <div className="form-group w-100">
              <label htmlFor="name">Nome</label>
              <Input
                id="name"
                name="name"
                className="shadow-sm"
                onChange={handleChange}
              />
            </div>
            <div className="form-group w-100">
              <label htmlFor="short_name">Abreviação</label>
              <Input
                id="short_name"
                name="shortName"
                className="shadow-sm"
                onChange={handleChange}
              />
            </div>
          </section>

          <section>
            <div>
              <h4>Membros</h4>
              <p>Selecione todos os membros do time.</p>
            </div>
            <div className="pb-2 bg-2 rounded shadow">
              <Table.Component>
                <Table.Head className="bg-3">
                  <tr>
                    <th className="text-center">#</th>
                    <th className="text-center">Foto</th>
                    <th>Nome</th>
                    <th>Email</th>
                    <th></th>
                  </tr>
                </Table.Head>
                <Table.Body>
                  <Users />
                </Table.Body>
              </Table.Component>
            </div>
          </section>

          <section>
            <input
              type="submit"
              className="btn btn-primary"
              value="Criar time"
            />
          </section>
        </form>
      </div>
    </HomeLayout>
  )
}
