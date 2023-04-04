import "./ShowOffers.css";
import "../../Components/SharedComponents/Modal/Modal.css";
import OfferMapper from "../../Components/OfferMapper";
import OfferShower from "../../Components/OfferShower";
import { useState,  useContext } from "react";
import { Form, Row, Col } from "react-bootstrap";
import OfferContext from "../../context/OfferContext";
import { useAuth } from "../../context/AuthContext/AuthContext";
import Modal from "react-bootstrap/Modal";
import { Link } from "react-router-dom";

const ShowOffers = () => {
  const [show, setShow] = useState(false);
  const [postulationSuccess, setPostulationSuccess] = useState(false);
  const [postulationError, setPostulationError] = useState(false);
  const [presentationMessage, setPresentationMessage] = useState("");
  const { showingOffer } = useContext(OfferContext);
  const { token, userDetails } = useAuth();
  const todayDate = new Date();
  const createDate = todayDate;

  const handleClose = () => {
    setShow(false);
  };

  const handleShow = () => {
    setShow(true);
    setPostulationSuccess(false);
    setPostulationError(false);
    setPresentationMessage("");
  };

  const studentPostulation = async (e) => {
    e.preventDefault();
    fetch("https://localhost:7264/api/postulation/studentPostulation", {
      method: "POST",
      headers: {
        "Content-type": "application/json; charset=UTF-8",
        Authorization: `Bearer ${token["accessToken"]}`,
      },
      body: JSON.stringify({
        presentation: presentationMessage,
        creationDate: createDate,
        studentId: userDetails.id,
        jobOfferId: showingOffer.id,
        linkCV: "..",
      }),
    })
      .then((res) => {
        if (!res.ok) {
          setPostulationError(true);
          throw new Error(res.status);
        } else {
          setPostulationSuccess(true);
          return res.json();
        }
      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  const canPostulate = () => {
    return (
      userDetails.phoneNumber > 0 &&
      userDetails.currentCity !== "" &&
      userDetails.personalId > 0 &&
      userDetails.curriculum !== "" &&
      userDetails.cuit > 0
    );
  };

  return (
    <div className="offerContainer">
      <>
        <h1 id="showOffersTitle">Propuestas recomendadas</h1>
        <Form id="showOffersForm">
          <Col md={10}>
            <Row>
            </Row>
            <Row>
              <Col md={4}>
                <div id='offerMapperDiv'>
                  <OfferMapper 
                    myOffers={false}
                  />
                </div> 
              </Col>
              <Col md={6}>
                {showingOffer.title == null ? (
                  <div className="container"></div>
                ) : (
                  <OfferShower
                    offer={showingOffer}
                    onClick={handleShow}
                    type="button"
                  />
                )}
              </Col>
            </Row>
          </Col>
          <Modal
            show={show}
            onHide={handleClose}
            aria-labelledby="contained-modal-title-vcenter"
            centered
          >
            <Modal.Header closeButton>
              <Modal.Title className="fs-5">Postulación</Modal.Title>
            </Modal.Header>
            <Modal.Body className="modal-postulation">
              {canPostulate() === true &&
                postulationSuccess === false &&
                postulationError === false && (
                  <>
                    <label htmlFor="presentation">
                      Mensaje de presentación (opcional){" "}
                    </label>
                    <textarea
                      type="text"
                      name="presentation"
                      class="form-control"
                      maxLength="200"
                      value={presentationMessage}
                      onChange={(e) => setPresentationMessage(e.target.value)}
                    ></textarea>{" "}
                  </>
                )}
              {canPostulate() === true && postulationSuccess === true && (
                <p className="text-light">Postulación enviada con éxito</p>
              )}
              {canPostulate() === false ? (
                <>
                  <p className="text-light">
                    Debe completar la información obligatoria en su perfil para
                    poder postularse a las ofertas.
                  </p>
                  <p>
                    <Link
                      aria-current="page"
                      to="/profile"
                      className="text-center link text-decoration-underline"
                    >
                      Ir a mi perfil
                    </Link>
                  </p>
                </>
              ) : null}
              {postulationError === true && (
                <>
                  <p className="text-light">Error</p>
                  <p className="text-light">
                    Ya se ha registrado tu postulación para esta oferta.
                  </p>
                </>
              )}
            </Modal.Body>
            <Modal.Footer className="modal-postulation">
              {canPostulate() === true &&
              postulationSuccess === false &&
              postulationError === false ? (
                <>
                  <button class="btn btn-outline-danger" onClick={handleClose}>
                    Cancelar
                  </button>
                  <button
                    onClick={studentPostulation}
                    class="btn btn-outline-success"
                  >
                    Enviar postulación
                  </button>
                </>
              ) : (
                <button onClick={handleClose} class="btn btn-outline-light">
                  Cerrar
                </button>
              )}
            </Modal.Footer>
          </Modal>
        </Form>
      </>
    </div>
  );
};

export default ShowOffers;
