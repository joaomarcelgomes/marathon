import moment from 'moment'
import { useState } from 'react'
import { Link } from 'react-router-dom'
import HomeLayout from '@/layouts/Home'
import useAuth from '@/hooks/use-auth'
import Table from '@/components/Table'
import Input from '@/components/Input'
import Icon from '@/components/Icon'
import api from '@/lib/axios/api'

export function Competitions() {
  const { user } = useAuth()
  const [search, setSearch] = useState('')

  const removeCompetition = async (id: number) => {
    await api.competition.remove(id)
    window.location.reload()
  }

  const competitions = user.competitions.filter(
    (competition) =>
      competition.name.toLowerCase().includes(search.toLowerCase()) ||
      competition.description.toLowerCase().includes(search.toLowerCase())
  )

  const UserCompetitions = () => {
    if (competitions.length == 0)
      return (
        <tr>
          <td colSpan={9}>
            <div className="min-vh-100 d-flex flex-column text-center justify-content-center">
              <h3>Nenhuma competição encontrada</h3>
            </div>
          </td>
        </tr>
      )

    return competitions.map((competition, i) => (
      <tr key={i}>
        <td align="center">{competition.id}</td>
        <td>{competition.name}</td>
        <td>{competition.description}</td>
        <td className="text-nowrap">{competition.prize}</td>
        <td align="center">{competition.teams.length}</td>
        <td align="center">{moment(competition.start).format('DD/MM/YYYY')}</td>
        <td align="center">{moment(competition.end).format('DD/MM/YYYY')}</td>
        <td align="center">
          {moment().isAfter(competition.end) ? 'Sim' : 'Não'}
        </td>
        <td align="right">
          <a
            href={`/competicoes/edita/${competition.id}`}
            className="btn d-inline-block"
          >
            <Icon.Edit />
          </a>
          <button
            className="btn d-inline-block"
            onClick={() => removeCompetition(competition.id)}
          >
            <Icon.Delete />
          </button>
        </td>
      </tr>
    ))
  }

  return (
    <HomeLayout>
      <div className="container-fluid mt-4 max-w-lg min-w-sm h-100">
        <h1>Competições</h1>
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
          <Link className="btn btn-primary" to="/competicoes/cria">
            <Icon.Plus size={14} className="mr-3" />
            Nova Competição
          </Link>
        </section>

        <section>
          <div className="min-vh-100 m-4 mx-auto bg-6 rounded">
            <Table.Component>
              <Table.Head className="bg-5">
                <tr>
                  <th className="text-center">#</th>
                  <th>Nome</th>
                  <th>Descrição</th>
                  <th>Prêmio</th>
                  <th className="text-center">Times</th>
                  <th className="text-center">Início</th>
                  <th className="text-center">Fim</th>
                  <th className="text-center">Acabou</th>
                  <th></th>
                </tr>
              </Table.Head>
              <Table.Body>
                <UserCompetitions />
              </Table.Body>
            </Table.Component>
          </div>
        </section>
      </div>
    </HomeLayout>
  )
}
