import React from "react";
import "./Login.css";
import LoginForm from "../Components/UI/Forms/LoginForm/LoginForm";

const Login = () => {
  return (
    <div id="login-page">
      <p id="presentation-text">
        La Bolsa de Trabajo UTN es un servicio gratuito de intermediación
        laboral que fortalece el vínculo entre estudiantes y graduados de la UTN
        y el sistema productivo.
      </p>
      <LoginForm />
    </div>
  );
};

export default Login;
