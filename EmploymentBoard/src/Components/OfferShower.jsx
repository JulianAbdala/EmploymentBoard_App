import React from "react";

import "./OfferShower.css";

import { Row, Col, Card } from "react-bootstrap";
import SmallButton from "./SharedComponents/SmallButton";

const OfferShower = ({ offer, onClick, type }) => {
  return (
    <Card id="offerShowerContainer">
      <Row className="titleRow">
        <Col md={8}>
          <Card.Title id="offerTitle">
            {(offer.enterpriseName ? offer.enterpriseName : "Empresa") +
              " busca:"}
          </Card.Title>
          <Card.Title id="offerTitle2" className="title2">
            {offer.title}
          </Card.Title>
          <Card.Subtitle>
            {offer.experience === 1
              ? `${offer.experience} año de experiencia`
              : offer.experience !== 0
              ? `${offer.experience} años de experiencia`
              : "No requiere experiencia"}
          </Card.Subtitle>
        </Col>
        <Col className="btnCol">
          <SmallButton btnText={"Postularse"} onClick={onClick} type={type}/>
        </Col>
      </Row>
      <Card.Body className="card-body p-0 ">
        <Card.Text className="offerDescription">{offer.description}</Card.Text>
      </Card.Body>
    </Card>
  );
};

export default OfferShower;
