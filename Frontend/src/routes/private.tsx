import Teams from '@/pages/Teams'
import Competitions from '@/pages/Competitions'
import Profile from '@/pages/Profile'

export default [
  {
    path: '/',
    element: <Competitions />,
  },
  {
    path: '/times',
    element: <Teams />,
  },
  {
    path: '/perfil',
    element: <Profile />,
  },
]
