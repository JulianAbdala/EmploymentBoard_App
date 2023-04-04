import React, {useState} from "react";
import EnterpriseMapper from "./EnterpriseMapper";
import StudentMapper from "./StudentMapper";
import "./Solicitudes.css";

const Solicitudes = () => {

    const [radioValue, setRadioValue] = useState("student");

    const handleRadio = (e) => {
      setRadioValue(e.target.value);
    };
  
    return (
        <>
        <div className="btn-request">
          <div
            className="btn-group btn-group-lg "
            role="group"
            aria-label="Basic radio toggle button group"
          >
            <input
              type="radio"
              className="btn-check"
              value="student"
              name="btnradio"
              id="btnradio1"
              autoComplete="off"
              onChange={handleRadio}
            />
            <label className="btn btn-outline-primary" htmlFor="btnradio1">
              Solicitudes de Alumnos
            </label>

            <input
              type="radio"
              className="btn-check"
              value="enterprise"
              name="btnradio"
              id="btnradio2"
              autoComplete="off"
              onChange={handleRadio}
            />
            <label className="btn btn-outline-primary" htmlFor="btnradio2">
              Solicitudes de Empresas
            </label>
          </div>
          </div>
          {radioValue === "student" && (
            <StudentMapper />
          )}
          {radioValue === "enterprise" && (
            <EnterpriseMapper />
          )}
        </>
    );
  };
  
  export default Solicitudes;
  