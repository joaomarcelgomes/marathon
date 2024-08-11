import Login from '@/pages/Login'
import Logout from '@/pages/Logout'
import Register from '@/pages/Register'

export default [
  {
    path: '/login',
    element: <Login />,
  },
  {
    path: '/logout',
    element: <Logout />,
  },
  {
    path: '/cadastro',
    element: <Register />,
  },
]
