import React, {useEffect, useState} from "react";
import { useAuth } from '../context/AuthContext/AuthContext';
import Accordion from "./SharedComponents/Accordion";
import Modal from "react-bootstrap/Modal";
import { useNavigate } from "react-router-dom";
import "./StudentMapper.css";

const StudentMapper = () => {

    const [SAccount, setSAccount] = useState([]);
    const [showModal, setShowModal] = useState(false);
    const [selectedId, setSelectedId] = useState(null);
    const [isAccepting, setIsAccepting] = useState(null);
    const navigate = useNavigate();
    const { token } = useAuth();

    const handleClose = () => {
      setSelectedId(null);
      setShowModal(false);
    };
  
    const handleShow = (Id, isAccepted) => {
      setIsAccepting(isAccepted);
      setSelectedId(Id);
      setShowModal(true);
    };

    const handleAccepted = async (e) => {
      e.preventDefault();
      if(isAccepting){
      await fetch(`https://localhost:7264/api/students/updateStatus/${selectedId}`, {
          method: "PUT",
          body: JSON.stringify({
            id: selectedId,
            accountStatus: 0,
          }),
          headers: {
            "Content-type": "application/json; charset=UTF-8",
            Authorization: `Bearer ${token["accessToken"]}`,
          },
        });}else{
          await fetch(`https://localhost:7264/api/students/updateStatus/${selectedId}`, {
          method: "PUT",
          body: JSON.stringify({
            id: selectedId,
            accountStatus: 1,
          }),
          headers: {
            "Content-type": "application/json; charset=UTF-8",
            Authorization: `Bearer ${token["accessToken"]}`,
          },
        })}

        navigate(0);
    }

    useEffect(() => {
        const headers = { "Content-Type": "application/json" };
        if (token) {
          headers["Authorization"] = `Bearer ${token["accessToken"]}`;
        }
        fetch("https://localhost:7264/api/students/getPendingStudents", { headers })
          .then((response) => response.json())
          .then((data) => setSAccount(data), );
        }, [token]);



    return (
        
        <div className="mapper-content">
            {SAccount.length === 0 ? <h1 className="mapper-h1">No hay solicitudes</h1> :
            <div className="accordion">
                {SAccount.map(({ id, email, firstName, lastName, fileNumber }) => (
                <Accordion Id={id} Email={email} FirstName={firstName} LastName={lastName} FileNumber={fileNumber} key={id} handleShow={handleShow} />
                ))}
            </div>}
            <Modal
            show={showModal}
            onHide={handleClose}
            aria-labelledby="contained-modal-title-vcenter"
            centered>
            <Modal.Header closeButton>
              <Modal.Title className="fs-5">¡Advertencia!</Modal.Title>
            </Modal.Header>
            <Modal.Body className="modal-postulation">
              {isAccepting ? <p className="text-light">¿Estás seguro que deseas aceptar la solicitud?</p> : <p className="text-light">¿Estás seguro que deseas rechazar la solicitud?</p>}
            </Modal.Body>
            <Modal.Footer>
                <button class="btn btn-outline-light" onClick={handleAccepted}>
                Aceptar
                </button>
                <button class="btn btn-outline-light" onClick={handleClose}>
                  Cancelar
                </button>
            </Modal.Footer>

            </Modal>
        </div>
    )
}

export default StudentMapper;