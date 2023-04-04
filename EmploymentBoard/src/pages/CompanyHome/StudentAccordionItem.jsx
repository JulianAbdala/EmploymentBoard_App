import React from 'react'
import { Accordion, Col, Row } from 'react-bootstrap'
import download from 'downloadjs';
import { useAuth } from '../../context/AuthContext/AuthContext';
import "./StudentAccordion.css"
import SmallButton from '../../Components/SharedComponents/SmallButton';

const StudentAccordionItem = ({index, name, lastName, studentId, email, careerName, setShowSpinner}) => {
	const {token} = useAuth();
	const onClick = (e) => {
		e.preventDefault()
		console.log("Hola")
		fetch(`https://localhost:7264/api/students/DownloadCV?UserId=${studentId}`, {headers: {Authorization: `Bearer ${token["accessToken"]}`}})
		  .then((response) => response.blob())
		  .then((data) => download(data, `${name}_${lastName}_CV.pdf`), );
	}
	return (
		<Accordion.Item eventKey={`${index}`}>
			<Accordion.Header>
				<h4 className="accordionH3">{`Postulante ${name} ${lastName}`}</h4>
			</Accordion.Header>
			<Accordion.Body>
				<Row>
					<span> <b>Estudiante de la carrera: </b> Tecnicatura en Programación</span>
					<span> <b>Email de contacto:</b>{` ${email}`}</span>
					<Col md={4}/>
					<Col md={3}>
					<SmallButton onClick={onClick} btnText={'Descargar CV'}/>
					</Col>
					
				</Row>
			</Accordion.Body>
		</Accordion.Item>
	)
}

export default StudentAccordionItem