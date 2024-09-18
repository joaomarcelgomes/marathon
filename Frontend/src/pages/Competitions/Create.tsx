import { useState } from 'react'
import HomeLayout from '@/layouts/Home'
import useAuth from '@/hooks/use-auth'
import Input from '@/components/Input'
import Textarea from '@/components/Textarea'
import Select from '@/components/Select'
import Table from '@/components/Table'
import Checkbox from '@/components/Checkbox'
import api from '@/lib/axios/api'

export function Create() {
  const { user } = useAuth()
  const [form, setForm] = useState({
    name: '',
    description: '',
    prize: '',
    start: '',
    end: '',
    teamsIds: [],
  })

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault()
    await api.competition.create({ userId: user.id, ...form })
    window.location.href = '/'
  }

  const handleCheckboxChange = (id: number) => {
    if (form.teamsIds.includes(id)) {
      const teamsIds = form.teamsIds.filter((memberId) => memberId !== id)
      setForm({ ...form, teamsIds })
    } else {
      const teamsIds = [...form.teamsIds, id]
      setForm({ ...form, teamsIds })
    }
  }

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    setForm({ ...form, [e.target.name]: e.target.value })
  }

  const Teams = () => {
    return user.teams.map((team, i) => (
      <tr key={i}>
        <td align="center">
          <b>{team.id}</b>
        </td>
        <td>{team.name}</td>
        <td align="center">{team.shortName}</td>
        <td align="center">{team.users.length}</td>
        <td align="center">
          <img src={team.imageUrl} width={24} height={24} alt={team.name} />
        </td>
        <td>
          <Checkbox
            id={'team_option_' + i}
            checked={form.teamsIds.includes(team.id)}
            onChange={() => handleCheckboxChange(team.id)}
          />
        </td>
      </tr>
    ))
  }

  return (
    <HomeLayout>
      <div className="container max-w-lg min-w-sm min-vh-100 mt-4">
        <form
          onSubmit={handleSubmit}
          className="min-w-sm mx-auto p-8 d-flex flex-column gap-5"
          autoComplete="off"
        >
          <section>
            <h1 className="mb-0">Criar competição</h1>
          </section>

          <section className="d-flex flex-column gap-4">
            <div className="form-group">
              <label htmlFor="name">Nome</label>
              <Input
                id="name"
                name="name"
                className="shadow-sm"
                onChange={handleChange}
              />
            </div>
            <div className="form-group">
              <label htmlFor="description">Descrição</label>
              <Textarea
                id="description"
                name="description"
                className="shadow-sm"
                onChange={handleChange}
              />
            </div>
            <div className="form-group">
              <label htmlFor="prize">Prêmio</label>
              <Input
                id="prize"
                name="prize"
                className="shadow-sm"
                onChange={handleChange}
              />
            </div>
            <div className="d-flex flex-row gap-4">
              <div className="form-group w-100">
                <label htmlFor="start">Início</label>
                <Input
                  id="start"
                  name="start"
                  type="date"
                  className="shadow-sm"
                  onChange={handleChange}
                />
              </div>
              <div className="form-group w-100">
                <label htmlFor="end">Fim</label>
                <Input
                  id="end"
                  name="end"
                  type="date"
                  className="shadow-sm"
                  onChange={handleChange}
                />
              </div>
            </div>
          </section>

          <section className="d-flex flex-column gap-4 mt-2">
            <div>
              <h4>Times</h4>
              <p className="mb-0">Selecione todos os times da competição.</p>
            </div>
            <div className="form-group">
              <Select.Component id="teams">
                <Select.Option value="4">4 times</Select.Option>
                <Select.Option value="8">8 times</Select.Option>
                <Select.Option value="16">16 times</Select.Option>
              </Select.Component>
            </div>

            <div className="pb-2 bg-2 rounded shadow">
              <Table.Component>
                <Table.Head className="bg-3">
                  <tr>
                    <th className="text-center">#</th>
                    <th>Nome</th>
                    <th className="text-center">Abreviação</th>
                    <th className="text-center">Competidores</th>
                    <th className="text-center">Escudo</th>
                    <th></th>
                  </tr>
                </Table.Head>
                <Table.Body>
                  <Teams />
                </Table.Body>
              </Table.Component>
            </div>
          </section>

          <section>
            <input
              type="submit"
              className="btn btn-primary"
              value="Criar competição"
            />
          </section>
        </form>
      </div>
    </HomeLayout>
  )
}
