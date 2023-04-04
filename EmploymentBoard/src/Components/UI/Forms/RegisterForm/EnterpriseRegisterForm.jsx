import React, { useState, useEffect } from "react";
import Button from "../../../SharedComponents/Button";
import "./StudentRegisterForm.css";
const EnterpriseRegisterForm = (props) => {
  const [enterpriseDetails, setEnterpriseDetails] = useState({});
  const [formErrors, setFormErrors] = useState({});

  const handleInput = (e) => {
    setEnterpriseDetails({
      ...enterpriseDetails,
      [e.target.name]: e.target.value,
    });
  };

  const validate = (values) => {
    const errors = {};

    if (!values.name) {
      errors.name = "El nombre de la empresa es obligatorio.";
    }
    if (!values.email) {
      errors.email = "Debe ingresar su correo.";
    } else if (!new RegExp(/\S+@\S+\.\S+/).test(enterpriseDetails.email)) {
      errors.email = "Formato de correo inválido.";
    }
    if (!values.password) {
      errors.password = "Debe ingresar su contraseña.";
    } else if (enterpriseDetails.password.length < 8) {
      errors.password = "La contraseña debe tener un mínimo de 8 caracteres.";
    } else if (
      !new RegExp(
        /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/
      ).test(enterpriseDetails.password)
    ) {
      errors.password =
        "Debe contener al menos un número, una letra y un caracter especial.";
    }

    if (!values.location) {
      errors.location = "Debe ingresar la localidad.";
    } else if (!new RegExp(/^[a-zA-Z ]*$/).test(enterpriseDetails.location)) {
      errors.location = "Ingrese solo caracteres válidos.";
    }

    if (!values.field) {
      errors.field = "El rubro es obligatorio.";
    } else if (!new RegExp(/^[a-zA-Z ]*$/).test(enterpriseDetails.field)) {
      errors.field = "Ingrese solo caracteres válidos.";
    }

    if (!values.cuit) {
      errors.cuit = "El CUIT es obligatorio.";
    } else if (
      !new RegExp(/^(20|23|27|30|33)([0-9]{9}|-[0-9]{8}-[0-9]{1})$/g).test(
        enterpriseDetails.cuit
      )
    ) {
      errors.cuit = "El CUIT no es válido.";
    }
    setFormErrors(errors);
    return errors;
  };

  useEffect(() => {
    setFormErrors({});
  }, [enterpriseDetails]);

  const enterpriseRegistration = async (e) => {
    e.preventDefault();
    const error = validate(enterpriseDetails);
    if (Object.keys(error).length === 0) {
      fetch("https://localhost:7264/api/enterprises/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          Name: enterpriseDetails.name,
          Field: enterpriseDetails.field,
          Cuit: enterpriseDetails.cuit,
          Location: enterpriseDetails.location,
          Email: enterpriseDetails.email,
          Password: enterpriseDetails.password,
        }),
      })
        .then((res) => {
          res.json();
          props.setRegister(true);
        })
        .catch((err) => {
          console.log(err.message);
        });
    }
  };

  return (
    <div>
      {!props.register && (
        <form class="form-container">
          <div className="register-form">
            <div className="child1">
              <label for="enterpriseName">Nombre de la empresa</label>
              <input
                onChange={handleInput}
                value={enterpriseDetails.name}
                className="txt-input"
                name="name"
                type="text"
                id="name"
              />
              <div id="err-cont">
                <p id="errorReg">{formErrors.name}</p>
              </div>
              <label for="enterpriseField">Rubro</label>
              <input
                onChange={handleInput}
                value={enterpriseDetails.field}
                className="txt-input"
                name="field"
                type="text"
                id="field"
              />
              <div id="err-cont">
                <p id="errorReg">{formErrors.field}</p>
              </div>
              <label for="enterpriseCuit">CUIT</label>
              <input
                onChange={handleInput}
                value={enterpriseDetails.cuit}
                className="txt-input"
                name="cuit"
                type="text"
                id="cuit"
              />
              <div id="err-cont">
                <p id="errorReg">{formErrors.cuit}</p>
              </div>
            </div>
            <div className="child2">
              <label for="enterpriseLocation">Localidad</label>
              <input
                onChange={handleInput}
                value={enterpriseDetails.location}
                className="txt-input"
                name="location"
                type="text"
                id="location"
              />
              <div id="err-cont">
                <p id="errorReg">{formErrors.location}</p>
              </div>
              <label for="enterpriseEmail">Email</label>
              <input
                onChange={handleInput}
                value={enterpriseDetails.email}
                className="txt-input"
                name="email"
                type="text"
                id="email"
              />
              <div id="err-cont">
                <p id="errorReg">{formErrors.email}</p>
              </div>

              <label for="enterprisePassword">Contraseña</label>
              <input
                onChange={handleInput}
                value={enterpriseDetails.password}
                className="txt-input"
                name="password"
                type="password"
                id="password"
              />
              <div id="err-cont">
                <p id="errorReg">{formErrors.password}</p>
              </div>
            </div>
          </div>
          <div className="button">
            <Button
              type="button"
              onClick={enterpriseRegistration}
              btnText={"Registrarse como empresa"}
            />
          </div>
        </form>
      )}
    </div>
  );
};

export default EnterpriseRegisterForm;
