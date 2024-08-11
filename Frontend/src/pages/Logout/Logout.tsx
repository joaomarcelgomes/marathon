import useAuth from '@/hooks/use-auth'
import { Navigate } from 'react-router-dom'

export function Logout() {
  const { signout, authenticated } = useAuth()

  if (authenticated) {
    signout()
  }

  return <Navigate to="/login" />
}
