import '@/styles/app.css'
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom'
import { AuthProvider } from './contexts/AuthContext'
import useAuth from '@/hooks/use-auth'

import PUBLIC from '@/routes/public'
import PRIVATE from '@/routes/private'

function App() {
  return (
    <AuthProvider>
      <BrowserRouter>
        <Routes>
          {PUBLIC.map((route, key) => (
            <Route key={key} path={route.path} element={route.element} />
          ))}
          {PRIVATE.map((route, key) => (
            <Route
              key={key}
              path={route.path}
              element={<Private>{route.element}</Private>}
            />
          ))}
        </Routes>
      </BrowserRouter>
    </AuthProvider>
  )
}

const Private: React.FC<{
  children: React.ReactNode
}> = ({ children }) => {
  const { loading, authenticated } = useAuth()

  if (loading) {
    return <></>
  }

  return authenticated ? children : <Navigate to="/login" replace />
}

export default App
