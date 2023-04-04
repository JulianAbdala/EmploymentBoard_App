import React, { useState, useEffect } from "react";
import { Col, FormControl, FormLabel } from "react-bootstrap";
import { FormSelect as Select } from "react-bootstrap";
import Button from "../../Components/SharedComponents/Button";
import { useAuth } from "../../context/AuthContext/AuthContext";

const StudentSkills = () => {
  const [inputList, setInputList] = useState([
    { skillName: "", level: "", skillId: "" },
  ]);
  const { token, userDetails } = useAuth();

  useEffect(() => {
    const headers = { "Content-Type": "application/json" };
    if (token) {
      headers["Authorization"] = `Bearer ${token["accessToken"]}`;

      fetch(
        `https://localhost:7264/api/studentSkills/getMySkills?studentId=${userDetails.id}`,
        { headers }
      )
        .then((response) => response.json())
        .then((data) => setInputList(data));
    }
  }, [token]);

  console.log(inputList);

  const handleInputChange = (e, index) => {
    const { name, value } = e.target;
    const list = [...inputList];
    list[index][name] = value;
    setInputList(list);
  };

  const handleRemoveClick = (index) => {
    const list = [...inputList];
    list.splice(index, 1);
    setInputList(list);
  };

  const handleAddClick = () => {
    setInputList([...inputList, { skillName: "", level: "" }]);
  };
  console.log(inputList);
  return (
    <>
      <div
        style={{
          overflowY: "scroll",
          overflowX: "hidden",
          maxHeight: "65vh",
          maxWidth: "200vh",
        }}
        className="justify-content-center"
      >
        {inputList.map((x, i) => {
          return (
            <>
              <div className="row justify-content-center mt-4">
                <Col md={2}>
                  <FormLabel>Conocimiento</FormLabel>
                  <FormControl
                    type="text"
                    className="txt-input"
                    name="skillName"
                    placeholder="Ej: 'Java', 'C#', etc."
                    value={x.skillName}
                    id={x.skillId}
                    onChange={(e) => handleInputChange(e, i)}
                  />
                </Col>
                <Col md={2}>
                  <FormLabel>Nivel</FormLabel>
                  <Select
                    name="level"
                    value={x.level}
                    required
                    onChange={(e) => handleInputChange(e, i)}
                  >
                    <option selected disabled>
                      --Seleccione su nivel--
                    </option>
                    <option value={0}>Básico</option>
                    <option value={1}>Intermedio</option>
                    <option value={2}>Avanzado</option>
                  </Select>
                </Col>
                <Col md={2} className="mt-2">
                  {inputList.length !== 1 && (
                    <button
                      className="btn btn-danger mt-4"
                      onClick={() => handleRemoveClick(i)}
                    >
                      Eliminar
                    </button>
                  )}
                </Col>
              </div>
              <div className="row justify-content-center ms-6">
                <Col md={6}>
                  {inputList.length - 1 === i && (
                    <button
                      onClick={handleAddClick}
                      className="btn btn-success mt-2"
                    >
                      Agregar
                    </button>
                  )}
                </Col>
              </div>
            </>
          );
        })}
      </div>
      <div className="row justify-content-center mt-4">
        <Button
          btnText={"Guardar cambios"}
          className="justify-self-center"
        ></Button>
      </div>
    </>
  );
};

export default StudentSkills;
