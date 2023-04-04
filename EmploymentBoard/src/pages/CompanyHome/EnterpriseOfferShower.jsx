import React, { useEffect } from 'react'

import '../../Components/OfferShower.css'

import { Row, Col, Card } from 'react-bootstrap'
import SmallButton from '../../Components/SharedComponents/SmallButton'
import { useAuth } from '../../context/AuthContext/AuthContext'


const EnterpriseOfferShower = ( {offer, postulationsClick, postulations, setPostulations, students, setStudents, setShowSpinner} ) => {
	const { token } = useAuth();

	const handleClick = async (e) => {
		e.preventDefault();
		const headers = { "Content-Type": "application/json" };
		headers["Authorization"] = `Bearer ${token["accessToken"]}`;
		await fetch(`https://localhost:7264/api/postulation/jobOfferId?id=${offer.id}`, { headers })
			.then((response) => response.json())
			.then((data) => setPostulations(data))
			.then(postulationsClick());
	}
	useEffect(() => {
		if(postulations !== []) {
			setStudents(postulations.map((postulation) => {
				return {
					name: postulation.student.firstName,
					lastName: postulation.student.lastName,
					email: postulation.student.email,
					careerName: postulation.student.careerName,
					studentId: postulation.studentId
				}
			}))
		}
	  }, [postulations]);
  return (
    <Card id='offerShowerContainer'>
		<Row className='titleRow'>
			<Col md={8}>
				<Card.Title id='offerTitle'>{(offer.enterpriseName? offer.enterpriseName : "Empresa") + " busca:"}</Card.Title>
				<Card.Title id='offerTitle2' className="title2">{offer.title}</Card.Title>
				<Card.Subtitle>{offer.experience===1? `${offer.experience} año de experiencia`: offer.experience !== 0? `${offer.experience} años de experiencia` : "No requiere experiencia"}</Card.Subtitle>
			</Col>
			<Col className="btnCol">
				<SmallButton btnText={"Ver postulantes"} onClick={handleClick}/>
			</Col>
		</Row>
			<Card.Body className='card-body p-0 '>
			<Card.Text className='offerDescription'>{offer.description}</Card.Text>
		</Card.Body>
  		</Card>	
  )
}

export default EnterpriseOfferShower