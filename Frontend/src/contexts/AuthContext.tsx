import React, { useState } from 'react'
import * as cookies from '@/utils/cookies'
import api from '@/lib/axios/api'
import type { User } from 'auth'

export type AuthContext = {
  user: User
  loading: boolean
  authenticated: boolean
  register: (name: string, email: string, password: string) => Promise<void>
  signin: (email: string, password: string) => Promise<void>
  signout: () => void
  updateUser: (name: string, email: string, password: string) => Promise<void>
  removeUser: () => Promise<void>
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
    cookies.setSession(response.data.data.token)
    setUser(response.data.data.user as User)
  }

  const signin = async (email: string, password: string) => {
    const response = await api.user.login(email, password)
    cookies.setSession(response.data.data.token)
    setUser(response.data.data.user as User)
  }

  const signout = () => {
    cookies.removeSession()
    setUser(null)
  }

  const updateUser = async (name: string, email: string, password: string) => {
    await api.user.update(user.id, name, email, password)
    setUser((data) => ({ ...data, name, email }))
  }

  const removeUser = async () => {
    await api.user.remove(user.id)
    cookies.removeSession()
    setUser(null)
  }

  return (
    <AuthContext.Provider
      value={{
        user,
        loading,
        authenticated,
        register,
        signin,
        signout,
        updateUser,
        removeUser,
      }}
    >
      {children}
    </AuthContext.Provider>
  )
}

export default AuthContext
