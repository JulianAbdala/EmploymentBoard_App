import { useState, useEffect } from "react";
import Button from "../../Components/SharedComponents/Button";
import { useAuth } from "../../context/AuthContext/AuthContext";
import "./StudentProfile.css";

const EnterpriseProfile = () => {
  const { token, userDetails, setUserDetails } = useAuth();
  const [isReadonly, setIsReadonly] = useState(true);
  const [formErrors, setFormErrors] = useState({});

  useEffect(() => {
    setFormErrors({});
    validate(userDetails);
  }, [userDetails]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    const error = validate(userDetails);
    if (Object.keys(error).length === 0) {
      fetch("https://localhost:7264/api/enterprises/updateProfile", {
        method: "PUT",
        body: JSON.stringify({
          address: userDetails.address,
          website: userDetails.website,
          contactName: userDetails.contactName,
          contactPosition: userDetails.contactPosition,
          contactPhoneNumber: userDetails.contactPhoneNumber,
          contactEmail: userDetails.contactEmail,
          phoneNumber: userDetails.phoneNumber,
          enterpriseRelation: userDetails.enterpriseRelation,
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

  const isButtonSelected = (value) => {
    if (userDetails.enterpriseRelation === value) {
      return true;
    }
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
      !new RegExp(/^(http[s]?:\/\/(www\.)?|ftp:\/\/(www\.)?|www\.){1}([0-9A-Za-z-.@:%_+~#=]+)+((\.[a-zA-Z]{2,3})+)(\/(.)*)?(\?(.)*)?/g).test(values.website) &&
      values.website
    ) {
      errors.website = "Ingrese una URL válida.";
    }
    if (
      !new RegExp(
        /^(?:(?:00)?549?)?0?(?:11|[2368]\d)(?:(?=\d{0,2}15)\d{2})??\d{8}$/
      ).test(values.contactPhoneNumber) &&
      values.contactPhoneNumber
    ) {
      errors.contactPhoneNumber= "El número de teléfono no es válido.";
    }
    if (
      !new RegExp(/\S+@\S+\.\S+/).test(values.contactEmail) &&
      values.contactEmail
    ) {
      errors.contactEmail= "El correo no es válido.";
    }
    if (
      !new RegExp(/^[a-zA-Z ]*$/).test(values.contactName) &&
      values.contactName
    ) {
      errors.contactName = "Ingrese solo caracteres válidos.";
    }

    setFormErrors(errors);
    return errors;
  };

  return (
    <div className="form-wrapper">
      <form className="form-container">
        <h3>{userDetails.name}</h3>
        <br />
        <br />
        <div class="row">
          <div class="form-group col-md-12 d-flex justify-content-end">
            <h5 style={{ color: "white" }}>Datos de contacto</h5>
          </div>
        </div>
        <div class="row">
          <div class="form-group col-md-4">
            <label for="name">Nombre de la empresa</label>
            <input
              type="text"
              class="form-control-plaintext"
              id="name"
              value={userDetails.name}
              readOnly
            />
            <br />
            <label for="field">Rubro</label>
            <input
              type="text"
              class="form-control-plaintext"
              id="field"
              value={userDetails.field}
              readOnly
            />
            <br />
            <label htmlFor="inputEmail">Email</label>
            <input
              type="email"
              class="form-control-plaintext"
              id="email"
              value={userDetails.email}
              readOnly
            />
            <br />
            <label for="location">Localidad</label>
            <input
              type="text"
              class="form-control-plaintext"
              id="location"
              value={userDetails.location}
              readOnly
            />

            <br />
            <label htmlFor="cuit">CUIT</label>
            <input
              type="email"
              class="form-control-plaintext"
              id="cuit"
              value={userDetails.cuit}
              readOnly
            />
            <br />
          </div>

          <div class="form-group col-md-4">
            <label htmlFor="phoneNumber">Teléfono</label>
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

            <label for="address">Domicilio legal</label>
            <br />
            {!userDetails.address && (
              <small id="addressHelp" class="form-text text-muted">
                Por favor complete el campo vacío.
              </small>
            )}
            <input
              type="text"
              class={isReadonly ? "form-control-plaintext" : "form-control"}
              id="address"
              name="address"
              maxLength="50"
              value={userDetails.address}
              onChange={handleInput}
              readOnly={isReadonly}
            />
            <div id="err-cont">
              <p id="error">{formErrors.address}</p>
            </div>

            <label for="website">Web</label>
            <br />
            {!userDetails.website && (
              <small id="webHelp" class="form-text text-muted">
                Por favor complete el campo vacío.
              </small>
            )}
            <input
              type="text"
              class={isReadonly ? "form-control-plaintext" : "form-control"}
              id="website"
              name="website"
              maxLength="50"
              value={userDetails.website}
              onChange={handleInput}
              readOnly={isReadonly}
            />
            <div id="err-cont">
              <p id="error">{formErrors.website}</p>
            </div>
            <br />
          </div>

          <div class="form-group col-md-4">
            <label for="contactName">Nombre y apellido</label>
            <br />
            {!userDetails.contactName && (
              <small id="idContactName" class="form-text text-muted">
                Por favor complete el campo vacío.
              </small>
            )}
            <input
              type="text"
              class={isReadonly ? "form-control-plaintext" : "form-control"}
              id="contactName"
              name="contactName"
              value={userDetails.contactName}
              onChange={handleInput}
              readOnly={isReadonly}
            />
            <div id="err-cont">
              <p id="error">{formErrors.contactName}</p>
            </div>

            <label for="position">Puesto</label>
            <br />
            {!userDetails.contactPosition && (
              <small id="idContactPosition" class="form-text text-muted">
                Por favor complete el campo vacío.
              </small>
            )}
            <input
              type="text"
              class={isReadonly ? "form-control-plaintext" : "form-control"}
              id="contactPosition"
              name="contactPosition"
              value={userDetails.contactPosition}
              onChange={handleInput}
              readOnly={isReadonly}
            />
            <div id="err-cont">
              <p id="error">{formErrors.contactPosition}</p>
            </div>

            <label htmlFor="phone">Teléfono de contacto</label>
            <br />
            {!userDetails.contactPhoneNumber && (
              <small id="contactPhoneNumberHelp" class="form-text text-muted">
                Por favor complete el campo vacío.
              </small>
            )}
            <input
              type="text"
              class={isReadonly ? "form-control-plaintext" : "form-control"}
              id="contactPhoneNumber"
              name="contactPhoneNumber"
              value={userDetails.contactPhoneNumber}
              onChange={handleInput}
              readOnly={isReadonly}
            />
            <div id="err-cont">
              <p id="error">{formErrors.contactPhoneNumber}</p>
            </div>

            <label for="contactEmail">Email</label>
            <br />
            {!userDetails.contactEmail && (
              <small id="contactEmailHelp" class="form-text text-muted">
                Por favor complete el campo vacío.
              </small>
            )}
            <input
              type="text"
              class={isReadonly ? "form-control-plaintext" : "form-control"}
              id="contactEmail"
              name="contactEmail"
              maxLength="50"
              value={userDetails.contactEmail}
              onChange={handleInput}
              readOnly={isReadonly}
            />
            <div id="err-cont">
              <p id="error">{formErrors.contactEmail}</p>
            </div>

            {!userDetails.enterpriseRelation && (
              <small id="enterpriseRelationHelp" class="form-text text-muted">
                Por favor seleccione una opción.
              </small>
            )}
            <br />
            <div className="form-check">
              <input
                class="form-check-input"
                type="radio"
                name="enterpriseRelation"
                value="Member"
                id="enterpriseRelation"
                onClick={handleInput}
                checked={isButtonSelected("Member")}
                disabled={isReadonly}
              />
              <label class="form-check-label" for="enterpriseRelation">
                Trabajo en la empresa
              </label>
            </div>
            <div class="form-check">
              <input
                class="form-check-input"
                type="radio"
                name="enterpriseRelation"
                value="Consultant"
                id="enterpriseRelation"
                onClick={handleInput}
                checked={isButtonSelected("Consultant")}
                disabled={isReadonly}
              />
              <label class="form-check-label" for="flexRadioDefault2">
                Trabajo en una consultora
              </label>
            </div>
          </div>
        </div>
        <br />
        <div class="btn-container">
          <Button
            type="button"
            onClick={handleClick}
            btnText={isReadonly ? "Editar información" : "Guardar Cambios"}
          />
        </div>
      </form>
    </div>
  );
};

export default EnterpriseProfile;
