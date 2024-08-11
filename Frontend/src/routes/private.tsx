import Home from '@/pages/Home'
import Teams from '@/pages/Teams'
import Competitions from '@/pages/Competitions'
import Profile from '@/pages/Profile'

export default [
  {
    path: '/',
    element: <Home />,
  },
  {
    path: '/times',
    element: <Teams />,
  },
  {
    path: '/competicoes',
    element: <Competitions />,
  },
  {
    path: '/perfil',
    element: <Profile />,
  },
]
