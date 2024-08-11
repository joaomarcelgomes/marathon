import '@/styles/app.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom'

import Home from '@/pages/Home'
import Login from '@/pages/Login'
import Register from '@/pages/Register'
import Teams from '@/pages/Teams'
import Competitions from '@/pages/Competitions'
import Profile from '@/pages/Profile'

function App() {
  return (
    <div className="app">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/cadastro" element={<Register />} />
          <Route path="/times" element={<Teams />} />
          <Route path="/competicoes" element={<Competitions />} />
          <Route path="/perfil" element={<Profile />} />
        </Routes>
      </BrowserRouter>
    </div>
  )
}

export default App
