import React, { useState } from 'react'
import * as cookies from '@/utils/cookies'
import api from '@/lib/axios/api'
import type { User } from 'auth'

export type AuthContext = {
  loading: boolean
  authenticated: boolean
  register: (name: string, email: string, password: string) => Promise<void>
  signin: (email: string, password: string) => Promise<void>
  signout: () => void
}

export const AuthContext = React.createContext({} as AuthContext)

export const AuthProvider: React.FC<{
  children: React.ReactNode
}> = ({ children }) => {
  const [user, setUser] = useState<User | null>(null)
  const [loading, setLoading] = useState(true)

  const authenticated = !!user

  const retrieveUser = async () => {
    try {
      const response = await api.user.me()
      setUser(response.data.data as User)
    } catch {
      setUser(null)
    } finally {
      setLoading(false)
    }
  }

  React.useEffect(() => {
    retrieveUser()
  }, [])

  const register = async (name: string, email: string, password: string) => {
    const response = await api.user.register(name, email, password)
    setUser(response.data.data.user as User)
    cookies.setSession(response.data.data.token)
  }

  const signin = async (email: string, password: string) => {
    const response = await api.user.login(email, password)
    setUser(response.data.data.user as User)
    cookies.setSession(response.data.data.token)
  }

  const signout = () => {
    setUser(null)
    cookies.removeSession()
  }

  return (
    <AuthContext.Provider
      value={{ loading, authenticated, register, signin, signout }}
    >
      {children}
    </AuthContext.Provider>
  )
}

export default AuthContext
