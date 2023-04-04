import React, {useState} from "react";
import "./AdminDashboard.css";
import Solicitudes from "../../Components/Solicitudes"
import CareerForm from "../../Components/UI/Forms/CareerForm/CareerForm";


const AdminDashboard = () => {
  const [active, setActive] = useState("solicitudes");

  const handleActive = (e) => {
    setActive(e.target.value);
  };

  return (
    <>
      <ul className="nav nav-tabs">
        <li className="nav-item">
          <button
            className="nav-link"
            onClick={handleActive}
            value="solicitudes"
          >
            Solicitudes
          </button>
        </li>
        <li className="nav-item">
          <button className="nav-link" onClick={handleActive} value="careerOptions">
            Administrar Carreras
          </button>
        </li>
      </ul>
      {active === "solicitudes" && <Solicitudes />}
      {active === "careerOptions" && <CareerForm />}
    </>
  );
};

export default AdminDashboard;
