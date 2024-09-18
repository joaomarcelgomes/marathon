import React, { useState } from 'react'
import retrieveUser from '@/utils/retrieve-user'
import * as cookies from '@/utils/cookies'
import api from '@/lib/axios/api'

export type AuthContext = {
  user: User
  loading: boolean
  authenticated: boolean
  register: (data: CreateUserRequest) => Promise<void>
  signin: (data: LoginRequest) => Promise<void>
  signout: () => void
  updateUser: (data: UpdateUserRequest) => Promise<void>
  removeUser: () => Promise<void>
}

export const AuthContext = React.createContext({} as AuthContext)

export const AuthProvider: React.FC<{
  children: React.ReactNode
}> = ({ children }) => {
  const [user, setUser] = useState<User | null>(null)
  const [loading, setLoading] = useState(true)

  const authenticated = !!user

  const setCurrentUser = async () => {
    setLoading(true)
    const currentUser = await retrieveUser()
    setUser(currentUser)
    setLoading(false)
  }

  React.useEffect(() => {
    setCurrentUser()
  }, [])

  const register = async (data: CreateUserRequest) => {
    const response = await api.user.create(data)
    cookies.setSession(response.data.data.token)
    setUser(response.data.data.user as User)
  }

  const signin = async (data: LoginRequest) => {
    const response = await api.user.login(data)
    cookies.setSession(response.data.data.token)
    setCurrentUser()
  }

  const signout = () => {
    cookies.removeSession()
    setUser(null)
  }

  const updateUser = async (data: UpdateUserRequest) => {
    data = {
      id: user.id,
      name: user.name,
      email: user.email,
      avatar: user.avatar,
      ...data,
    }
    await api.user.update(data)
    setUser({ ...user, ...data })
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
