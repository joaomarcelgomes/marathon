import './Register.css'
import { useState } from 'react'
import { useNavigate, Link } from 'react-router-dom'

import urlApi from '@/axios/config'
import InputGroup from '@/components/InputGroup'

const Register = () => {
  const navigate = useNavigate()
  const [name, setName] = useState()
  const [email, setEmail] = useState()
  const [password, setPassword] = useState()
  const [confirmPassword, setConfirmPassword] = useState()
  const [error, setError] = useState()

  const createUser = async (e) => {
    e.preventDefault()
    if (!name || !email || !password || !confirmPassword) {
      setError('Por favor, preencha todos os campos')
      return
    } else if (password != confirmPassword) {
      setError('Confirmar senha deve ser igual a senha')
      return
    } else if (password.length < 8) {
      setError('A senha deve conter pelo menos 8 caracteres')
      return
    }

    const user = { name, email, password }

    try {
      await urlApi.post('/user/create', user)
      navigate('/')
    } catch (error) {
      console.error('Erro ao criar usuário:', error)
      setError(
        'Ocorreu um erro ao criar o usuário. Por favor, tente novamente mais tarde.'
      )
    }
  }

  return (
    <div className="w-100 m-auto font-custom-div">
      <form onSubmit={(e) => createUser(e)}>
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
              type="text"
              name="name"
              placeholder="Nome Completo"
              iconSrc="/person-icon.png"
              onChange={(e) => setName(e.target.value)}
            />
          </div>
          <div className="mb-4">
            <InputGroup
              type="email"
              name="email"
              placeholder="Email"
              iconSrc="/email-icon.png"
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>
          <div className="mb-4">
            <InputGroup
              type="password"
              name="password"
              placeholder="Email"
              iconSrc="/lock-icon.png"
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>
          <div className="mb-4">
            <InputGroup
              type="password"
              name="confirmPassword"
              placeholder="Confirmar Senha"
              iconSrc="/lock-icon.png"
              onChange={(e) => setConfirmPassword(e.target.value)}
            />
          </div>
        </div>
        {error && (
          <div className="alert alert-danger" role="alert">
            {error}
          </div>
        )}
        <input
          className="btn btn-primary color-custom w-100"
          type="submit"
          value="Cadastrar"
        />
        <label className="mt-4" htmlFor="">
          Já possui uma conta?{' '}
        </label>{' '}
        <Link to="/">
          <label htmlFor="" className="font-custom">
            Entre
          </label>
        </Link>
      </form>
    </div>
  )
}

export default Register
