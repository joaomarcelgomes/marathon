import './Register.css'
import { Link } from 'react-router-dom'

import urlApi from '../../axios/config'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'

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
          <div className="input-group mb-4 mt-4">
            <span className="input-group-text background-custom border-0">
              <img src="/person-icon.png" alt="pessoa" />
            </span>
            <input
              className="form-control background-custom border-0 form-control-lg"
              type="text"
              name="name"
              placeholder="Nome Completo"
              onChange={(e) => setName(e.target.value)}
            />
          </div>

          <div className="input-group mb-4">
            <span className="input-group-text background-custom border-0">
              <img src="/email-icon.png" alt="email" />
            </span>
            <input
              className="form-control background-custom border-0 form-control-lg"
              type="email"
              name="email"
              placeholder="Email"
              onChange={(e) => setEmail(e.target.value)}
            />
          </div>

          <div className="input-group mb-4">
            <span className="input-group-text background-custom border-0">
              <img src="/lock-icon.png" alt="password" />
            </span>
            <input
              className="form-control background-custom border-0 form-control-lg"
              type="password"
              name="password"
              placeholder="Senha"
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>

          <div className="input-group mb-4">
            <span className="input-group-text background-custom border-0">
              <img src="/lock-icon.png" alt="password" />
            </span>
            <input
              className="form-control background-custom border-0 form-control-lg"
              type="password"
              name="confirmPassword"
              placeholder="Confirmar Senha"
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
