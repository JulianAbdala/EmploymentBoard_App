import React, { useState, useEffect } from "react";
import ChargeOffers from "./ChargeOffers";
import MyOffers from "./MyOffers";
import "./CompanyHome.css";
import { Col, Row } from "react-bootstrap";
import ChargeOfferForm from "../../Components/UI/Forms/ChargeOfferForm/ChargeOfferForm";

const Register = () => {
  const [radioValue, setRadioValue] = useState("");
  const [companyHomeDivId, setCompanyHomeDivId] = useState("companyHomeDiv");

  const handleRadio = (e) => {
    setRadioValue(e.target.value);
  };

  useEffect(() => {
		if (radioValue !== "")
      setCompanyHomeDivId("")
	  }, [radioValue]);

  return (
    <div>
      <div id={companyHomeDivId}>
        {radioValue === "chargeOffer" || radioValue === "myOffers" ? (
          <Row id="buttonsRow">
            <Col md={3}>
              <div
                class="btn-group btn-group-lg"
                role="group"
                aria-label="Basic radio toggle button group"
              >
                <input
                  type="radio"
                  class="btn-check"
                  value="chargeOffer"
                  name="btnradio"
                  id="btnradio1"
                  autocomplete="off"
                  onChange={handleRadio}
                />
                <label class="btn btn-outline-primary" for="btnradio1">
                  Cargar Ofertas
                </label>

                <input
                  type="radio"
                  class="btn-check"
                  value="myOffers"
                  name="btnradio"
                  id="btnradio2"
                  autocomplete="off"
                  onChange={handleRadio}
                />
                <label class="btn btn-outline-primary" for="btnradio2">
                  Mis Ofertas
                </label>
              </div>
            </Col>
          </Row>
        ) : (
          <div
            class="btn-group btn-group-lg"
            role="group"
            aria-label="Basic radio toggle button group"
          >
            <input
              type="radio"
              class="btn-check"
              value="chargeOffer"
              name="btnradio"
              id="btnradio1"
              autocomplete="off"
              onChange={handleRadio}
            />
            <label class="btn btn-outline-primary" for="btnradio1">
              Cargar Ofertas
            </label>

            <input
              type="radio"
              class="btn-check"
              value="myOffers"
              name="btnradio"
              id="btnradio2"
              autocomplete="off"
              onChange={handleRadio}
            />
            <label class="btn btn-outline-primary" for="btnradio2">
              Mis Ofertas
            </label>
          </div>
        )}
        {radioValue === "chargeOffer" && <ChargeOfferForm />}
        {radioValue === "myOffers" && <MyOffers />}
      </div>
    </div>
  );
};

export default Register;
