import React, { useState, useEffect } from "react";
import Select from "react-select";
import Button from "../../../SharedComponents/Button";
import { useAuth } from '../../../../context/AuthContext/AuthContext';
import ShowCareers from "./ShowCareers";
import "./CareerForm.css";

const CareerForm = (props) => {

  const { token } = useAuth();
  const [careerInfo, setCareerInfo] = useState({});
  const [formErrors, setFormErrors] = useState({});
  const [career, setCareer] = useState([]);
  const [show, setShow] = useState(false);

  const careers = [
    {label: "Tecnicatura", value: 0},
    {label: "Grado", value: 1},
    {label: "Posgrado", value: 2},
    {label: "Maestría", value: 3},
    {label: "Especialización", value: 4}
  ]

  const handleInput = (e) => {
    setCareerInfo({
      ...careerInfo,
      [e.target.name]: e.target.value,
    });
  };

  const validate = (values) => {
    const errors = {};

    if (!values.careerName) {
      errors.careerName = "Ingrese el nombre de la carrera.";
    } else if (!new RegExp(/^[a-zA-Z ]*$/).test(careerInfo.careerName)) {
      errors.careerName = "Ingrese solo caracteres válidos.";
    }
    setFormErrors(errors);
    return errors;
  };
  useEffect(() => {
    setFormErrors({});
  }, [careerInfo]);

  useEffect(() => {
    const headers = { "Content-Type": "application/json" };
    if (token) {
      headers["Authorization"] = `Bearer ${token["accessToken"]}`;
    }
    fetch("https://localhost:7264/api/careers", { headers })
      .then((response) => response.json())
      .then((data) => setCareer(data), );
      
    }, [token]);

  const addCareer = async (e) => {
    e.preventDefault();
    const error = validate(careerInfo);
    if (Object.keys(error).length === 0) {
      fetch("https://localhost:7264/api/careers", {
        method: "POST",
        headers: {
            "Content-type": "application/json; charset=UTF-8",
            Authorization: `Bearer ${token["accessToken"]}`,
        },
        body: JSON.stringify({
          careerName: careerInfo.careerName,
          careerType: careerInfo.careerType,
        }),
      }).then((res) => {
        res.json();
        setShow(true);
      })
      .catch((err) => {
        console.log(err.message);
      });
    }

  };


    useEffect(() => {
        const headers = { "Content-Type": "application/json" };
        if (token) {
          headers["Authorization"] = `Bearer ${token["accessToken"]}`;
        }
        fetch("https://localhost:7264/api/careers", { headers })
          .then((response) => response.json())
          .then((data) => setCareer(data), )
          .then(setShow(false));

          setCareerInfo({
            ...careerInfo,
            careerName: "",

          });
          
        }, [show]);


  return (
    <div className="career-form-div">
      {!props.register && (
        <form className="form-container">
          <div className="career-form">
            <div className="child1">
              <label htmlFor="careerInfo">Nombre de la Carrera</label>
              <input
                onChange={handleInput}
                value={careerInfo.careerName}
                className="txt-input"
                name="careerName"
                type="text"
                id="careerName"
              />
              <div id="">
                <p id="error">{formErrors.careerName}</p>
              </div>
              <div>
              <label htmlFor="careerType">Tipo de Carrera</label>
              <Select
                options = {careers}
                onChange={(e) => setCareerInfo({...careerInfo, careerType: e.value})}
              />
              </div>
          </div>
          </div>
          <div className="button">
            <Button
              type="button"
              onClick={addCareer}
              btnText={"Cargar carrera"}
            />
          </div>
        </form>
      )}
      <div className="careers-container">
        <div>
        <table className="career-table">
                <thead>
                    <tr>
                        <th>Carrera</th>
                        <th>Tipo</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
        {career.map(({ careerId, careerName, careerType }) => (
              <ShowCareers id={careerId} careerName={careerName} careerType={careerType} key={careerId} setShow={setShow} careers={careers} setCareerInfo={setCareerInfo} careerInfo={careerInfo} />))}
        </table>
        </div>
      </div>
    </div>
  );
};

export default CareerForm;
