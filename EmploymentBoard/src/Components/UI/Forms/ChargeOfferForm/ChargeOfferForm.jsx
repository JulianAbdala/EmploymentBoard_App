import React, { useState } from "react";
import {
  Form,
  Col,
  Row,
  FormLabel,
  FormControl,
  FormSelect as Select,
} from "react-bootstrap";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import "./ChargeOfferForm.css";
import { useAuth } from "../../../../context/AuthContext/AuthContext";
import Button from "../../../SharedComponents/Button";
import { useNavigate } from "react-router-dom";

const ChargeOfferForm = () => {
  const { token, userDetails } = useAuth();
  const navigate = useNavigate();
  const todayDate = new Date();
  const createDate = todayDate;
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [endDate, setEndDate] = useState();
  const [experience, setExperience] = useState();
  const [workSchedule, setWorkSchedule] = useState("");
  const [jobType, setJobType] = useState("");
  const [formErrors, setFormErrors] = useState({});

  const inputHandler = (e) => {
    switch (e.target.id) {
      case "title":
        setTitle(e.target.value);
        break;
      case "description":
        setDescription(e.target.value);
        break;
      case "experience":
        setExperience(e.target.value);
        break;
      case "workSchedule":
        setWorkSchedule(e.target.value);
        break;
      case "jobType":
        setJobType(e.target.value);
        break;
      default:
        break;
    }
  };
  const handleDateChange = (date) => {
    setEndDate(date);
  };
  const validation = () => {
    let errors = {};
    if (title === "") errors.title = "Debe ingresar un título para la oferta";

    if (!description)
      errors.description = "Debe ingresar una descripción de la oferta laboral";

    if (!endDate) errors.endDate = "Debe ingresar una fecha de finalización";

    if (endDate <= todayDate)
      errors.endDate = "La fecha ingresada no es válida";

    if (!experience)
      errors.experience = "Debe seleccionar los años de experiencia requeridos";

    if (!workSchedule)
      errors.workSchedule = "Debe seleccionar la cantidad de horas laborales";

    if (!jobType) errors.jobType = "Debe seleccionar el tipo de trabajo";

    setFormErrors(errors);
    return errors;
  };

  // useEffect(() => {
  //   setFormErrors(validation);
  // }, [title, description, endDate, experience, workSchedule, jobType])

  const handleSubmit = (e) => {
    e.preventDefault();
    const error = validation();
    if (Object.keys(error).length === 0) {
      fetch("https://localhost:7264/api/jobOffers", {
        method: "POST",
        body: JSON.stringify({
          title: title,
          description: description,
          creationDate: createDate,
          active: true,
          endDate: endDate,
          experience: experience,
          workSchedule: workSchedule,
          jobType: jobType,
          enterpriseId: userDetails.id,
          enterpriseName: userDetails.name,
        }),
        headers: {
          "Content-type": "application/json; charset=UTF-8",
          Authorization: `Bearer ${token["accessToken"]}`,
        },
      })
        .then((res) => res.json())
		    .then((res) => {if(!res.errors){
          setFormErrors({});
          navigate(0);
        }})
        .catch((err) => {
          console.log(err.message);
        });

    }
  };
  return (
    <Form id="chargeOfferForm">
      <Row>
        <h4 className="chargeOfferFormTitle">Carga de ofertas de trabajo</h4>
      </Row>
      <Row id="inputRow">
        <Col id="inputColumns" md={4}>
          <FormLabel rmLabel id="chargeOffersLabels">Título de la oferta</FormLabel>
          <FormControl
            size="text"
            type="text"
            id="title"
            placeholder="Título..."
            value={title}
            onChange={inputHandler}
            required
          />
          <div id="err-cont">
            <p id="error">{formErrors.title}</p>
          </div>
        </Col>
        <Col id="inputColumns" md={4}>
          <FormLabel rmLabel id="chargeOffersLabels">Fecha de creación (día de hoy)</FormLabel>
          <DatePicker 
		  	selected={createDate} 
			disabled
			id="endDate"
		/>
        </Col>
        <Col id="inputColumns" md={4}>
          <FormLabel rmLabel id="chargeOffersLabels">Fecha de finalización de la oferta</FormLabel>
          <DatePicker
            id="endDate"
            selected={endDate}
            onChange={handleDateChange}
            required
            placeholderText="Elija fecha de finalización"
          />
          <div id="err-cont">
            <p id="error">{formErrors.endDate}</p>
          </div>
        </Col>
      </Row>
      <br />
      <Row>
        <Col md={12}>
          <FormLabel required rmLabel id="chargeOffersLabels">Descripción de la oferta</FormLabel>
          <FormControl
            id="description"
            as="textarea"
            rows={6}
            value={description}
            onChange={inputHandler}
            required
          />
          <div id="err-cont">
            <p id="error">{formErrors.description}</p>
          </div>
        </Col>
      </Row>
      <br />
      <Row>
        <Col md={4}>
          <FormLabel rmLabel id="chargeOffersLabels">Experiencia requerida</FormLabel>
          <Select 
            id="experience" 
            required 
            onChange={inputHandler} 
          >
            <option selected disabled>
              Elija los años de experiencia
            </option>
            <option value={0}>Sin experiencia</option>
            <option value={1}>1 año de experiencia</option>
            <option value={2}>2 años de experiencia</option>
            <option value={3}>3 años o más de experiencia</option>
          </Select>
          <div id="err-cont">
            <p id="error">{formErrors.experience}</p>
          </div>
        </Col>
        <Col md={4}>
          <FormLabel rmLabel id="chargeOffersLabels">Tipo de jornada laboral</FormLabel>
          <Select id="workSchedule" required onChange={inputHandler} >
            <option selected disabled>
              Elija el tipo de jornada
            </option>
            <option value="fullTime">Jornada Completa</option>
            <option value="halfTime">Media Jornada</option>
          </Select>
          <div id="err-cont">
            <p id="error">{formErrors.workSchedule}</p>
          </div>
        </Col>
        <Col md={4}>
          <FormLabel id="chargeOffersLabels">Tipo de trabajo</FormLabel>
          <Select id="jobType" required onChange={inputHandler} >
            <option selected disabled>
              Elija el tipo de trabajo
            </option>
            <option value="job">Trabajo</option>
            <option value="internship">Pasantía</option>
          </Select>
          <div id="err-cont">
            <p id="error">{formErrors.jobType}</p>
          </div>
        </Col>
      </Row>
      <Row id="chargeOfferButton">
        <Button btnText={"Cargar Oferta"} onClick={handleSubmit}>
          Cargar Oferta
        </Button>
      </Row>
    </Form>
  );
};

export default ChargeOfferForm;
