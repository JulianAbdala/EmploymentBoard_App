import React, {useState} from 'react';
import { Accordion } from 'react-bootstrap';
import "./Accordion.css";


const AccordionItem = ({ Id, Email, FirstName, LastName, FileNumber, handleShow}) => {
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
          <div>{FirstName + " " + LastName}</div>
        </div>
        {isActive && <div>
          <table className="table mb-0">
          <thead>
            <tr className='titles'>
              <th>Email</th>
              <th>Legajo</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
          <tr className='body'>
            <td>{Email}</td>
            <td>{FileNumber}</td>
            <td><button type="button" class="btn btn-outline-danger" onClick={handleReject}>Rechazar</button><button type="button" class="btn btn-outline-success" onClick={handleAccept}>Aceptar</button></td>
          </tr>
          </tbody>
          </table>
          </div>}
      </div>

    );
  };
  
  export default AccordionItem;