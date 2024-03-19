import './Register.css';
import { Link } from 'react-router-dom';

const Register = () => {
    return (
        <div className="w-100 m-auto font-custom-div">
            <form>
            <Link to="/"><img className='mb-5 mt-3' src="/marathon-logo.png" alt="logo marathon" /></Link>
                <div className="form-floating mb-3">
                    <div className="input-group mb-4 mt-4">
                        <span className="input-group-text background-custom border-0">
                            <img src="/person-icon.png" alt="pessoa"/>
                        </span>
                        <input className="form-control background-custom border-0 form-control-lg" type="text" name="name" placeholder="Nome Completo"/>
                    </div>

                    <div className="input-group mb-4">
                        <span className="input-group-text background-custom border-0">
                            <img src="/email-icon.png" alt="email" />
                        </span>
                        <input className="form-control background-custom border-0 form-control-lg" type="email" name="email" placeholder="Email"/>
                    </div>

                    <div className="input-group mb-4">
                        <span className="input-group-text background-custom border-0">
                            <img src="/lock-icon.png" alt="password" />
                        </span>
                        <input className="form-control background-custom border-0 form-control-lg" type="password" name="password" placeholder="Senha"/>
                    </div>

                    <div className="input-group mb-4">
                        <span className="input-group-text background-custom border-0">
                            <img src="/lock-icon.png" alt="password" />
                        </span>
                        <input className="form-control background-custom border-0 form-control-lg" type="password" name="confirmPassword" placeholder="Confirmar Senha"/>
                    </div>
                </div>
                    <input className="btn btn-primary color-custom w-100" type="submit" value="Cadastrar" />
                    <label className='mt-4' htmlFor="">Já possui uma conta? </label> <Link to="/"><label htmlFor="" className='font-custom'>Entre</label></Link>
            </form>
        </div>
    )
}

export default Register;
