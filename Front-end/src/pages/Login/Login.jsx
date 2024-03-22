import './Login.css'
import { Link } from 'react-router-dom'

import InputGroup from '@/components/InputGroup'

const Login = () => {
  return (
    <div className="div-pai">
      <form>
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
            />
          </div>
          <div className="mb-4">
            <InputGroup
              type="password"
              name="password"
              placeholder="Informe sua senha"
              iconSrc="/lock-icon.png"
            />
          </div>
        </div>
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
