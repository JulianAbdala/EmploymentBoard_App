import React, { useState, useEffect } from "react";
import Button from "../../../SharedComponents/Button";

const StudentRegisterForm = (props) => {
  const [studentDetails, setStudentDetails] = useState({});
  const [formErrors, setFormErrors] = useState({});

  const handleInput = (e) => {
    setStudentDetails({
      ...studentDetails,
      [e.target.name]: e.target.value,
    });
  };

  const validate = (values) => {
    const errors = {};

    if (!values.name) {
      errors.name = "Ingrese su nombre.";
    } else if (!new RegExp(/^[a-zA-Z ]*$/).test(studentDetails.name)) {
      errors.name = "Ingrese solo caracteres válidos.";
    }
    if (!values.email) {
      errors.email = "Debe ingresar su correo.";
    } else if (!new RegExp(/\S+@\S+\.\S+/).test(studentDetails.email)) {
      errors.email = "Formato de correo inválido.";
    }
    if (!values.password) {
      errors.password = "Debe ingresar su contraseña.";
    } else if (studentDetails.password.length < 8) {
      errors.password = "La contraseña debe tener un mínimo de 8 caracteres.";
    } else if (
      !new RegExp(
        /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/
      ).test(studentDetails.password)
    ) {
      errors.password =
        "Debe contener al menos un número, una letra y un caracter especial.";
    }

    if (!values.surname) {
      errors.surname = "Ingrese su apellido";
    } else if (!new RegExp(/^[a-zA-Z ]*$/).test(studentDetails.surname)) {
      errors.surname = "Ingrese solo caracteres válidos.";
    }
    if (!values.passwordConfirm) {
      errors.passwordConfirm = "Ingrese nuevamente la contrasena";
    } else if (studentDetails.passwordConfirm !== studentDetails.password) {
      errors.passwordConfirm = "Las contrasenas no coinciden";
    }
    if (!values.legajo) {
      errors.legajo = "Ingrese su legajo";
    } else if (!new RegExp(/^[0-9]*$/).test(studentDetails.legajo)) {
      errors.legajo = "Ingrese correctamente su legajo";
    } else if (studentDetails.legajo.length !== 5) {
      errors.legajo = "el legajo debe contener 5 caracteres";
    }

    setFormErrors(errors);
    return errors;
  };
  useEffect(() => {
    setFormErrors({});
  }, [studentDetails]);

  const studentRegistration = async (e) => {
    e.preventDefault();
    const error = validate(studentDetails);
    if (Object.keys(error).length === 0) {
      fetch("https://localhost:7264/api/students/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          FirstName: studentDetails.name,
          LastName: studentDetails.surname,
          FileNumber: studentDetails.legajo,
          Email: studentDetails.email,
          Password: studentDetails.password,
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
        <form className="form-container">
          <div className="register-form">
            <div className="child1">
              <label for="studentName">Nombre</label>
              <input
                onChange={handleInput}
                value={studentDetails.name}
                className="txt-input"
                name="name"
                type="text"
                id="name"
              />
              <div id="">
                <p id="errorReg">{formErrors.name}</p>
              </div>
              <label for="studentField">Apellido</label>
              <input
                onChange={handleInput}
                value={studentDetails.surname}
                className="txt-input"
                name="surname"
                type="text"
                id="surname"
              />
              <div id="">
                <p id="errorReg">{formErrors.surname}</p>
              </div>
              <label for="studentCuit">Legajo</label>
              <input
                onChange={handleInput}
                value={studentDetails.legajo}
                className="txt-input"
                name="legajo"
                type="text"
                id="legajo"
              />
              <div id="">
                <p id="errorReg">{formErrors.legajo}</p>
              </div>
            </div>
            <div className="child2">
              <label for="studentEmail">Email</label>
              <input
                onChange={handleInput}
                value={studentDetails.email}
                className="txt-input"
                name="email"
                type="text"
                id="email"
              />
              <div id="">
                <p id="errorReg">{formErrors.email}</p>
              </div>

              <label for="studentPassword">Contraseña</label>
              <input
                onChange={handleInput}
                value={studentDetails.password}
                className="txt-input"
                name="password"
                type="password"
                id="password"
              />
              <div id="">
                <p id="errorReg">{formErrors.password}</p>
              </div>
              <label for="studentPassword">Confirmar Contraseña</label>
              <input
                onChange={handleInput}
                value={studentDetails.passwordConfirm}
                className="txt-input"
                name="passwordConfirm"
                type="password"
                id="passwordConfirm"
              />
              <div id="">
                <p id="errorReg">{formErrors.passwordConfirm}</p>
              </div>
            </div>
          </div>
          <div className="button">
            <Button
              type="button"
              onClick={studentRegistration}
              btnText={"Registrarse"}
            />
          </div>
        </form>
      )}
    </div>
  );
};

export default StudentRegisterForm;
