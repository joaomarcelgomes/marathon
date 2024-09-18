import { Link } from 'react-router-dom'
import { useState } from 'react'
import HomeLayout from '@/layouts/Home'
import useAuth from '@/hooks/use-auth'
import Table from '@/components/Table'
import Input from '@/components/Input'
import Icon from '@/components/Icon'

export function Teams() {
  const { user } = useAuth()
  const [search, setSearch] = useState('')

  const teams = user.teams.filter(
    (team) =>
      team.name.toLowerCase().includes(search.toLowerCase()) ||
      team.shortName.toLowerCase().includes(search.toLowerCase())
  )

  const UserTeams = () => {
    if (teams.length == 0)
      return (
        <tr>
          <td colSpan={5}>
            <div className="min-vh-100 d-flex flex-column text-center justify-content-center">
              <h3>Nenhum time encontrado</h3>
            </div>
          </td>
        </tr>
      )

    return teams.map((team, i) => (
      <tr key={i}>
        <td align="center">{team.id}</td>
        <td align="center">{team.name}</td>
        <td align="center">{team.shortName}</td>
        <td align="center">{team.users.length}</td>
        <td align="center">
          <img src={team.imageUrl} width={24} height={24} alt={team.name} />
        </td>
      </tr>
    ))
  }

  return (
    <HomeLayout>
      <div className="container-fluid mt-4 max-w-lg min-w-sm min-vh-100">
        <h1>Times</h1>
        <section className="d-flex justify-content-between mt-4">
          <div className="w-50">
            <Input
              spellCheck="false"
              placeholder="Pesquisar"
              className="shadow-none"
              icon={<Icon.Search />}
              onChange={(e) => setSearch(e.target.value)}
            />
          </div>
          <Link className="btn btn-primary" to="/times/cria">
            <Icon.Plus size={14} className="mr-3" />
            Novo Time
          </Link>
        </section>

        <section>
          <div className="min-vh-100 m-4 mx-auto bg-6 rounded">
            <Table.Component>
              <Table.Head className="bg-5">
                <tr className="text-center">
                  <th>#</th>
                  <th>Nome</th>
                  <th>Abreviação</th>
                  <th>Competidores</th>
                  <th>Escudo</th>
                </tr>
              </Table.Head>
              <Table.Body>
                <UserTeams />
              </Table.Body>
            </Table.Component>
          </div>
        </section>
      </div>
    </HomeLayout>
  )
}
