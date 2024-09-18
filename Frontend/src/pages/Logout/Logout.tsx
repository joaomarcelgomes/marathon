import { useEffect } from 'react'
import useAuth from '@/hooks/use-auth'
import { Navigate } from 'react-router-dom'

export function Logout() {
  const { signout, authenticated } = useAuth()

  useEffect(() => {
    if (authenticated) {
      signout()
    }
  }, [authenticated, signout])

  return <Navigate to="/login" />
}
