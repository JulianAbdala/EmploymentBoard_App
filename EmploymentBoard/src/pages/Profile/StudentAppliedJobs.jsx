import React, { useContext } from 'react';
import StudentOfferMapper from "./StudentOfferMapper";
import OfferContext from "../../context/OfferContext";
import { Form, Row, Col } from "react-bootstrap";
import { StudentOfferShower } from './StudentOfferShower';

const StudentAppliedJobs = () => {
    const { showingOffer } = useContext(OfferContext);
  
    return (
    <div className="offerContainer">
      <>
        <Form id="showOffersForm">
          <Col md={10}>
            <Row>
              <Col md={4}>
              </Col>
            <Row>
            </Row>
              <Col md={4}>
                <div id="offerMapperDiv">
                  <StudentOfferMapper />
                </div>
              </Col>
              <Col md={6}>
                {showingOffer.title == null ? (
                  <div className="container"></div>
                ) : (
                  <StudentOfferShower
                    offer={showingOffer}
                    type="button"
                  />
                )}
              </Col>
            </Row>
          </Col>
        </Form>
      </>
    </div>
  )
}

export default StudentAppliedJobs