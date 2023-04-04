import { useState, useEffect } from "react";
import Button from "../../Components/SharedComponents/Button";
import { useAuth } from "../../context/AuthContext/AuthContext";
import "./StudentProfile.css";
import download from "downloadjs";
import { Row } from "react-bootstrap";
import "./StudentProfile.css";

const StudentPersonalInfo = () => {
  const { token, userDetails, setUserDetails } = useAuth();
  const [isReadonly, setIsReadonly] = useState(true);
  const [formErrors, setFormErrors] = useState({});
  const [curriculum, setCurriculum] = useState();

  useEffect(() => {
    setFormErrors({});
    validate(userDetails);
  }, [userDetails]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    const error = validate(userDetails);
    if (Object.keys(error).length === 0) {
      fetch("https://localhost:7264/api/students/updateProfile", {
        method: "PUT",
        body: JSON.stringify({
          phoneNumber: userDetails.phoneNumber,
          currentCity: userDetails.currentCity,
          personalId: userDetails.personalId,
          cuit: userDetails.cuit,
        }),
        headers: {
          "Content-type": "application/json; charset=UTF-8",
          Authorization: `Bearer ${token["accessToken"]}`,
        },
      })
        .then((res) => res.json())
        .catch((err) => {
          console.log(err.message);
        });
    }
  };

  const handleReadonly = () => {
    if (!(Object.keys(formErrors).length !== 0 && !isReadonly))
      setIsReadonly((prevState) => !prevState);
  };

  const handleInput = (e) => {
    !isReadonly &&
      setUserDetails({
        ...userDetails,
        [e.target.name]: e.target.value,
      });
  };

  const handleClick = (e) => {
    handleReadonly(e);
    !isReadonly && handleSubmit(e);
  };

  const validate = (values) => {
    const errors = {};
    if (
      !new RegExp(
        /^(?:(?:00)?549?)?0?(?:11|[2368]\d)(?:(?=\d{0,2}15)\d{2})??\d{8}$/
      ).test(values.phoneNumber) &&
      values.phoneNumber
    ) {
      errors.phoneNumber = "El número de teléfono no es válido.";
    }
    if (
      !new RegExp(/^[a-zA-Z ]*$/).test(values.currentCity) &&
      values.currentCity
    ) {
      errors.currentCity = "Ingrese solo caracteres válidos.";
    }
    if (
      !new RegExp(/^[\d]{1,3}\.?[\d]{3,3}\.?[\d]{3,3}$/).test(
        values.personalId
      ) &&
      values.personalId
    ) {
      errors.personalId = "El DNI no es válido.";
    }
    if (
      !new RegExp(/^(20|23|27|30|33)([0-9]{9}|-[0-9]{8}-[0-9]{1})$/g).test(
        values.cuit
      ) &&
      values.cuit
    ) {
      errors.cuit = "El CUIT no es válido.";
    }

    setFormErrors(errors);
    return errors;
  };

  const handleCurriculum = (e) => {
    if (e.target.files[0]) setCurriculum(e.target.files[0]);
  };

  const CVUpload = (e) => {
    e.preventDefault();
    if (curriculum) {
      const formData = new FormData();

      formData.append("StudentId", userDetails.id);
      formData.append("File", curriculum);

      fetch("https://localhost:7264/api/students/UploadCV", {
        method: "POST",
        body: formData,
        headers: {
          Authorization: `Bearer ${token["accessToken"]}`,
        },
      })
        .then((result) => {
          console.log("Success:", result);
        })
        .catch((error) => {
          console.error("Error:", error);
        });
    }
  };

  const CVDownload = (e) => {
    e.preventDefault();
    fetch(
      `https://localhost:7264/api/students/DownloadCV?UserId=${userDetails.id}`,
      { headers: { Authorization: `Bearer ${token["accessToken"]}` } }
    )
      .then((response) => response.blob())
      .then((data) =>
        download(
          data,
          `${userDetails.firstName}_${userDetails.lastName}_CV.pdf`
        )
      );
  };

  return (
    <>
      <div className="form-wrapper">
        <form className="form-container">
          <h4>
            {userDetails.firstName} {""} {userDetails.lastName}
          </h4>
          <br />
          <br />
          <div class="row">
            <div className="form-group col-md-4">
              <label htmlFor="username">Nombre</label>
              <input
                type="text"
                class="form-control-plaintext"
                id="username"
                value={userDetails.firstName}
                readOnly
              />
              <br />
              <br /><br />
              <label htmlFor="lastname">Apellido</label>
              <input
                type="text"
                class="form-control-plaintext"
                id="lastname"
                value={userDetails.lastName}
                readOnly
              />
              <br /><br />
              <label htmlFor="inputEmail">Email</label>
              <input
                type="email"
                class="form-control-plaintext"
                id="inputEmail"
                value={userDetails.email}
                readOnly
              />
              <br /><br />
              <label htmlFor="file-number">Legajo</label>
              <input
                type="text"
                class="form-control-plaintext"
                id="file-number"
                value={userDetails.fileNumber}
                readOnly
              />
            </div>

            <div class="form-group col-md-4">
              <label htmlFor="phoneNumber" required>
                Teléfono*
              </label>
              <br />
              {!userDetails.phoneNumber && (
                <small id="phoneHelp" class="form-text text-muted">
                  Por favor complete el campo vacío.
                </small>
              )}
              <input
                type="text"
                class={isReadonly ? "form-control-plaintext" : "form-control"}
                id="phone"
                name="phoneNumber"
                value={userDetails.phoneNumber}
                onChange={handleInput}
                readOnly={isReadonly}
              />
              <div id="err-cont">
                <p id="error">{formErrors.phoneNumber}</p>
              </div>
              <br />

              <label htmlFor="currentCity">Ciudad de residencia*</label>
              <br />
              {!userDetails.currentCity && (
                <small id="cityHelp" class="form-text text-muted">
                  Por favor complete el campo vacío.
                </small>
              )}
              <input
                type="text"
                class={isReadonly ? "form-control-plaintext" : "form-control"}
                id="currentCity"
                name="currentCity"
                maxLength="50"
                value={userDetails.currentCity}
                onChange={handleInput}
                readOnly={isReadonly}
              />
              <div id="err-cont">
                <p id="error">{formErrors.currentCity}</p>
              </div>
              <br />

              <label htmlFor="personalId">Número de documento*</label>
              <br />
              {!userDetails.personalId && (
                <small id="idHelp" class="form-text text-muted">
                  Por favor complete el campo vacío.
                </small>
              )}
              <input
                type="text"
                class={isReadonly ? "form-control-plaintext" : "form-control"}
                id="personalId"
                name="personalId"
                value={userDetails.personalId}
                onChange={handleInput}
                readOnly={isReadonly}
              />
              <div id="err-cont">
                <p id="error">{formErrors.personalId}</p>
              </div>
              <br />

              <label htmlFor="cuit">CUIT*</label>
              <br />
              {!userDetails.cuit && (
                <small id="idCuit" class="form-text text-muted">
                  Por favor complete el campo vacío.
                </small>
              )}
              <input
                type="text"
                class={isReadonly ? "form-control-plaintext" : "form-control"}
                id="cuit"
                name="cuit"
                value={userDetails.cuit}
                onChange={handleInput}
                readOnly={isReadonly}
              />
              <div id="err-cont">
                <p id="error">{formErrors.cuit}</p>
              </div>
            </div>
            <div class="form-group col-md-4">
              <div class="custom-file">
                <label class="custom-file-label" htmlFor="add-cv">
                  Curriculum Vitae*
                </label>
                <input
                  type="file"
                  className="filestyle"
                  data-classButton="btn btn-primary"
                  data-input="false"
                  data-classIcon="icon-plus"
                  data-buttonText="add."
                  onChange={handleCurriculum}
                />
                <Row>
                  <button className="CVButton" onClick={CVUpload}>
                    Cargar CV
                  </button>
                  <button className="CVButton" onClick={CVDownload}>
                    Descargar CV
                  </button>
                </Row>
                <br />
                <br />
                <label htmlFor="career">Carrera</label>
                <select id="career" class="form-control select-career" readOnly>
                  <option
                    selected
                    disabled
                    defaultValue={userDetails.carrerName}
                  >
                    Tecnicatura en programación
                  </option>
                </select>
                <br />
              </div>
            </div>
          </div>
          <br />
          <br />
          <small className="text-light fst-italic">
            * Información requerida para postularse a una oferta.
          </small>
          <div className="btn-container std">
            <Button
              type="button"
              onClick={handleClick}
              btnText={isReadonly ? "Editar información" : "Guardar Cambios"}
            />
          </div>
        </form>
      </div>
    </>
  );
};

export default StudentPersonalInfo;
