import moment from 'moment'
import HomeLayout from '@/layouts/Home'
import useAuth from '@/hooks/use-auth'
import Table from '@/components/Table'
import Button from '@/components/Button'
import Input from '@/components/Input'
import Icon from '@/components/Icon'

export function Competitions() {
  const { user } = useAuth()

  const Competitions = () => {
    if (user.competitions.length == 0)
      return (
        <tr>
          <td colSpan={7}>
            <div className="min-vh-100 d-flex flex-column text-center justify-content-center">
              <h3>Nenhuma competição encontrada</h3>
            </div>
          </td>
        </tr>
      )

    return user.competitions.map((competition) => (
      <tr>
        <td>{competition.name}</td>
        <td>{competition.description}</td>
        <td>{competition.prize}</td>
        <td>{competition.teams.length}</td>
        <td>{moment(competition.start).format('DD/MM/YYYY')}</td>
        <td>{moment(competition.end).format('DD/MM/YYYY')}</td>
        <td>{moment().isAfter(competition.end) ? 'Sim' : 'Não'}</td>
      </tr>
    ))
  }

  return (
    <HomeLayout>
      <div className="container-fluid mt-4 max-w-lg min-w-sm min-vh-100">
        <h1>Competições</h1>
        <section className="d-flex justify-content-between mt-4">
          <div className="w-50">
            <Input
              icon={<Icon.Search />}
              placeholder="Pesquisar"
              className="shadow-none"
            />
          </div>
          <Button icon={<Icon.Plus size={14} className="mr-3" />}>
            Nova Competição
          </Button>
        </section>
        <section>
          <div className="min-vh-100 m-4 mx-auto bg-6 rounded">
            <Table.Root>
              <Table.Head>
                <tr>
                  <th>Nome</th>
                  <th>Descrição</th>
                  <th>Prêmio</th>
                  <th>Times</th>
                  <th>Início</th>
                  <th>Fim</th>
                  <th>Acabou</th>
                </tr>
              </Table.Head>
              <Table.Body>
                <Competitions />
              </Table.Body>
            </Table.Root>
          </div>
        </section>
      </div>
    </HomeLayout>
  )
}
