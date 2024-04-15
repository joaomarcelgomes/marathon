import './Login.css'
import { Link } from 'react-router-dom'

import InputGroup from '@/components/InputGroup'
import urlApi from '@/axios/config'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'

const Login = () => {
  const navigate = useNavigate()
  const [email, setEmail] = useState()
  const [password, setPassword] = useState()
  const [error, setError] = useState()

  const logarUser = async (e) =>{
    e.preventDefault()
    if(!email || !password){
      setError("Por favor, preenchar todos os campos")
      return
    }

    const user = {
      email, 
      password
    }

    try {
      await urlApi.post('/user/login', user)
      navigate('/')
    } catch (error) {
      console.error('Erro ao encontrar usuário:', error)
      setError("Usuário inválido")
    }
  }

  return (
    <div className="div-pai">
      <form onSubmit={(e) => logarUser(e)}>
        <Link to="/">
          <img
            className="mb-5 mt-3"
            src="/marathon-logo.png"
            alt="logo marathon"
          />
        </Link>
        <div className="form-floating mb-3">
          <div className="mb-4">
            <InputGroup
              type="email"
              name="email"
              placeholder="Informe seu email"
              iconSrc="/email-icon.png"
              onChange = {(e) => setEmail(e.target.value)}
            />
          </div>
          <div className="mb-4">
            <InputGroup
              type="password"
              name="password"
              placeholder="Informe sua senha"
              iconSrc="/lock-icon.png"
              onChange = {(e) => setPassword(e.target.value) }
            />
          </div>
        </div>
        { error && (
          <div className='alert alert-danger' role='alert'>
            {error}
          </div>
        )
        }
        <input
          className="btn btn-primary color-custom w-100"
          type="submit"
          value="Entrar"
        />
        <label className="mt-4" htmlFor="">
          Ainda não tem uma conta?{' '}
        </label>{' '}
        <Link to="/cadastro">
          <label htmlFor="" className="font-custom">
            Cadastre-se
          </label>
        </Link>
      </form>
    </div>
  )
}

export default Login
