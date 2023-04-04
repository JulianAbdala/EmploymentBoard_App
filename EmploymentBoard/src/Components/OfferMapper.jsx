import React, { useEffect, useState } from "react";
import { useAuth } from "../context/AuthContext/AuthContext";
import OfferCard from "./UI/OfferCard";

const OfferMapper = ( {myOffers} ) => {
	const [jobOffers, setJobOffers] = useState([]);
	const [offersMapped, setOffersMapped] = useState([])
	const [colors, setColors] = useState([]);
	const { token, userDetails } = useAuth();

	useEffect(() => {
		const headers = { "Content-Type": "application/json" };
		if (token) {
		  headers["Authorization"] = `Bearer ${token["accessToken"]}`;
			
		if (myOffers){
			fetch(`https://localhost:7264/api/jobOffers/enterpriseId?id=${userDetails.id}`, { headers })
			.then((response) => response.json())
			.then((data) => setJobOffers(data), );
		} else {
				fetch("https://localhost:7264/api/jobOffers", { headers })
				.then((response) => response.json())
				.then((data) => setJobOffers(data), );
			}
		}
	  }, [token]);

	const handleColor = (index) => {
		let array = new Array(jobOffers.length);
		array[index] = 'selected';
		setColors(array);
	}
	useEffect(() => {
		setOffersMapped(jobOffers?.map((offer, index) => {
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
		  }));
	}, [jobOffers, colors])
	  
	return (
		<div>
			{offersMapped}
		</div>
	  )
	}
	

export default OfferMapper;
