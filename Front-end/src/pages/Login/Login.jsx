import './Login.css'
import { Link } from 'react-router-dom'

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
          <div className="input-group mb-4">
            <span className="input-group-text background-custom border-0">
              <img src="/email-icon.png" alt="email" />
            </span>
            <input
              className="form-control background-custom border-0 form-control-lg"
              type="email"
              name="email"
              placeholder="Informe seu email"
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
              placeholder="Informe sua senha"
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
