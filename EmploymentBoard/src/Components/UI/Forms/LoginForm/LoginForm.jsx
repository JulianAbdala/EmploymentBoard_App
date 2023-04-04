import { useState, useRef, useEffect } from "react";
import { useNavigate, Link } from "react-router-dom";
import "./LoginForm.css";
import { useAuth } from "../../../../context/AuthContext/AuthContext";
import Button from "../../../SharedComponents/Button";

const LoginForm = () => {
  const emailRef = useRef();
  const navigate = useNavigate();
  const { login, token } = useAuth();
  const [formErrors, setFormErrors] = useState({});
  const initialValues = { email: "", password: "" };
  const [formValues, setFormValues] = useState(initialValues);
  const [wrongCredentials, setWrongCredentials] = useState(false);

  useEffect(() => {
    emailRef.current.focus();
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormValues({ ...formValues, [name]: value });
  };

  useEffect(() => {
    setFormErrors({});
    setWrongCredentials(false);
  }, [formValues]);

  const validate = (values) => {
    const errors = {};
    if (!values.email) {
      errors.email = "Debe ingresar su correo.";
    } else if (!new RegExp(/\S+@\S+\.\S+/).test(formValues.email)) {
      errors.email = "Formato de correo inválido.";
    }
    if (!values.password) {
      errors.password = "Debe ingresar su contraseña.";
    } else if (formValues.password.length < 8) {
      errors.password = "La contraseña debe tener un mínimo de 8 caracteres.";
    }
    setFormErrors(errors);
    return errors;
  };

  const handleLogin = async (e) => {
    e.preventDefault();
    const error = validate(formValues);
    if (Object.keys(error).length === 0) {
      login(formValues).then(() => {
        if (token) {
          navigate("/Home");
        } else {
          setWrongCredentials(true);
        }
      });
    }
  };

  return (
    <section id="login-form">
      <form>
        <div className="form-section">
          <h3>Iniciar sesión</h3>
          <div className="lab-pass-container">
            <label htmlFor="email" className="label-input">
              Email
            </label>
            <p></p>
          </div>
          <input
            className="txt-input"
            name="email"
            type="text"
            ref={emailRef}
            id="email"
            autoComplete="off"
            onChange={handleChange}
            value={formValues.email}
          />
        </div>
        <div id="err-cont">
          <p id="error">{formErrors.email}</p>
        </div>
        <div className="lab-pass-container">
          <label htmlFor="password" className="label-input">
            Contraseña
          </label>
          <a href="#blank">
            <p className="pass-forgot">¿Olvidó su contraseña?</p>
          </a>
        </div>
        <input
          className="txt-input"
          name="password"
          type="password"
          label="Contraseña"
          id="password"
          autoComplete="off"
          onChange={handleChange}
          value={formValues.password}
        />
        {wrongCredentials && <p id="error">Email o contraseña incorrectos.</p>}
        <div id="err-cont">
          <p id="error">{formErrors.password}</p>
        </div>
        <div className="button-container">
          <Button btnText={"Ingresar"} onClick={handleLogin}></Button>
        </div>
        <span>
          <Link className="link" aria-current="page" to="/register">
            ¿No tiene cuenta? Registrarse.
          </Link>
        </span>
      </form>
      <p></p>
    </section>
  );
};

export default LoginForm;
