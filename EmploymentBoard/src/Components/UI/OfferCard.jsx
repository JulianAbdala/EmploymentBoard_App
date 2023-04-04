import React, { useContext } from 'react'

import './OfferCard.css'

import { Card } from 'react-bootstrap'
import OfferContext from '../../context/OfferContext';

const OfferCard = ({title, company, type, endDate, offer, handleColor, index, colors}) => {
	const { setShowingOffer } = useContext(OfferContext);

	const jobtype = type==="job"? "Trabajo" : "Pasantía"
	const date = new Date(endDate)
	const formattedDate = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear();

	const handleClick = () => {
		setShowingOffer(offer);
		handleColor(index)
	}

  return (
		<Card onClick={handleClick} id={colors[index]? "card-selected" : "card"}>
			<Card.Title>{title}</Card.Title>
			<Card.Body className='card-body p-0'>
				<Card.Text>Empresa: {company? company : "Empresa"}</Card.Text>
				<Card.Text>Tipo: {jobtype}</Card.Text>
				<Card.Text>Fecha de finalización: {formattedDate}</Card.Text>
			</Card.Body>
  		</Card>	
  )
}

export default OfferCard