import React, { useEffect, useState } from "react";
import { useAuth } from "../../context/AuthContext/AuthContext";
import OfferCard from "../../Components/UI/OfferCard";
import { Link } from "react-router-dom";

const StudentOfferMapper = ({ setOffersApplied }) => {
  const [studentJobOffers, setStudentJobOffers] = useState([]);
  const [offersMapped, setOffersMapped] = useState([]);
  const [colors, setColors] = useState([]);
  const { token, userDetails } = useAuth();

  useEffect(() => {
    const headers = { "Content-Type": "application/json" };
    if (token) {
      headers["Authorization"] = `Bearer ${token["accessToken"]}`;

      fetch(
        `https://localhost:7264/api/students/getAppliedOffers?studentId=${userDetails.id}`,
        { headers }
      )
        .then((response) => response.json())
        .then((data) => setStudentJobOffers(data));
    }
  }, [token]);

  const handleColor = (index) => {
    let array = new Array(studentJobOffers.length);
    array[index] = "selected";
    setColors(array);
  };
  useEffect(() => {
    setOffersMapped(
      studentJobOffers?.map((offer, index) => {
        return (
          <OfferCard
            key={index}
            index={index}
            title={offer.title}
            company={offer.enterpriseName}
            type={offer.jobType}
            endDate={offer.endDate}
            offer={offer}
            handleColor={handleColor}
            colors={colors}
          />
        );
      })
    );
  }, [studentJobOffers, colors]);

  return (
    <div className="text-center">
      {offersMapped.length > 0 ? (
        offersMapped
      ) : (
        <div>
          <p className="text-light fs-5 noOffers">
            Aun no te has postulado a ninguna oferta.
          </p>
          <br />
          <Link to="/Home" className="text-light fs-6 noOffers">
            Encuentra propuestas de tu interés
          </Link>
        </div>
      )}
    </div>
  );
};

export default StudentOfferMapper;
