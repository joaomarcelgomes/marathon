import HomeLayout from '@/layouts/Home'
import useAuth from '@/hooks/use-auth'
import Table from '@/components/Table'
import Button from '@/components/Button'
import Input from '@/components/Input'
import Icon from '@/components/Icon'

export function Teams() {
  const { user } = useAuth()

  const Teams = () => {
    if (user.teams.length == 0)
      return (
        <tr>
          <td colSpan={7}>
            <div className="min-vh-100 d-flex flex-column text-center justify-content-center">
              <h3>Nenhum time encontrado</h3>
            </div>
          </td>
        </tr>
      )

    return user.teams.map((team) => (
      <tr className="text-center">
        <td>{team.id}</td>
        <td>{team.name}</td>
        <td>{team.shortName}</td>
        <td>{team.members.length}</td>
        <td>
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
              icon={<Icon.Search />}
              placeholder="Pesquisar"
              className="shadow-none"
            />
          </div>
          <Button icon={<Icon.Plus size={14} className="mr-3" />}>
            Novo Time
          </Button>
        </section>
        <section>
          <div className="min-vh-100 m-4 mx-auto bg-6 rounded">
            <Table.Root>
              <Table.Head>
                <tr>
                  <th>#</th>
                  <th>Nome</th>
                  <th>Abreviação</th>
                  <th>Competidores</th>
                  <th>Escudo</th>
                </tr>
              </Table.Head>
              <Table.Body>
                <Teams />
              </Table.Body>
            </Table.Root>
          </div>
        </section>
      </div>
    </HomeLayout>
  )
}
