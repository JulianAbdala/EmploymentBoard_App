import React, {useState} from 'react';
import { Accordion } from 'react-bootstrap';
import "./Accordion.css";


const AccordionItem = ({ Id, Email, Name, Location, Cuit, Field, handleShow }) => {
    const [isActive, setIsActive] = useState(false);

    const handleReject = async (e) => {
      let isAccepted = false;
      e.preventDefault();
      handleShow(Id, isAccepted);
        
    };

    const handleAccept = async (e) => {
      let isAccepted = true;
      e.preventDefault();
      handleShow(Id, isAccepted);
    };



    return (
      <div className="accordion-item">
        <div className="name" onClick={() => setIsActive(!isActive)}>
          <div>{Name}</div>
        </div>
        {isActive && <div>
          <table className="table mb-0">
          <thead>
            <tr className='titles'>
              <th>Email</th>
              <th>Localidad</th>
              <th>Cuit</th>
              <th>Rubro</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
          <tr className='body'>
            <td>{Email}</td>
            <td>{Location}</td>
            <td>{Cuit}</td>
            <td>{Field}</td>
            <td><button type="button" className="btn btn-outline-danger" onClick={handleReject}>Rechazar</button><button type="button" className="btn btn-outline-success" onClick={handleAccept} >Aceptar</button></td>
          </tr>
          </tbody>
          </table>
          </div>}
      </div>
    );
  };
  
  export default AccordionItem;