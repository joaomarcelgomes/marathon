import Teams from '@/pages/Teams'
import Competitions from '@/pages/Competitions'
import Profile from '@/pages/Profile'

export default [
  {
    path: '/',
    element: <Competitions.Main />,
  },
  {
    path: '/competicoes/cria',
    element: <Competitions.Create />,
  },
  {
    path: '/times',
    element: <Teams.Main />,
  },
  {
    path: '/times/cria',
    element: <Teams.Create />,
  },
  {
    path: '/perfil',
    element: <Profile />,
  },
]
