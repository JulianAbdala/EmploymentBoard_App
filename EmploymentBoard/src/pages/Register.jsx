import React, { useState } from "react";
import "./Register.css";
import StudentRegisterForm from "../Components/UI/Forms/RegisterForm/StudentRegisterForm";
import EnterpriseRegisterForm from "../Components/UI/Forms/RegisterForm/EnterpriseRegisterForm";

const Register = () => {
  const [register, setRegister] = useState(false);
  const [radioValue, setRadioValue] = useState("");

  const handleRadio = (e) => {
    setRadioValue(e.target.value);
  };

  return (
    <div id="register-page">
      {!register && (
        <>
          <div
            class="btn-group btn-group-lg"
            role="group"
            aria-label="Basic radio toggle button group"
          >
            <input
              type="radio"
              class="btn-check"
              value="student"
              name="btnradio"
              id="btnradio1"
              autocomplete="off"
              onChange={handleRadio}
            />
            <label class="btn btn-outline-primary" for="btnradio1">
              Soy alumno
            </label>

            <input
              type="radio"
              class="btn-check"
              value="enterprise"
              name="btnradio"
              id="btnradio2"
              autocomplete="off"
              onChange={handleRadio}
            />
            <label class="btn btn-outline-primary" for="btnradio2">
              Soy empresa
            </label>
          </div>
          {radioValue === "student" && (
            <StudentRegisterForm setRegister={setRegister} />
          )}
          {radioValue === "enterprise" && (
            <EnterpriseRegisterForm setRegister={setRegister} />
          )}
        </>
      )}
      {register && (
        <>
          <h4>Registro recibido con éxito</h4>
          <br />
          <p>
            La administración revisará su solicitud y se le informará por correo
            su aprobación o rechazo.
          </p>
          <p>El proceso puede tardar hasta 48hs.</p>
        </>
      )}
    </div>
  );
};

export default Register;
