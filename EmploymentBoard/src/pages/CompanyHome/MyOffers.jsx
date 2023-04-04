import React, { useState, useContext } from 'react'
import { Col, Form,  Modal, Row } from 'react-bootstrap'
import EnterpriseOfferShower from './EnterpriseOfferShower'
import OfferMapper from '../../Components/OfferMapper'
import OfferContext from '../../context/OfferContext'
import "./MyOffers.css";
import StudentAccordion from './StudentAccordion'




const MyOffers = () => {
	const [postulations, setPostulations] = useState([]);
	const [students, setStudents] = useState([]);
	const [showSpinner, setShowSpinner] = useState(true);
	const [isLookingPostulations, setIsLookingPostulations] = useState(false);

	const { showingOffer } = useContext(OfferContext);

  const postulationsClick = () => {
	setIsLookingPostulations(true);
  }

  const onModalHide = () => {
	setIsLookingPostulations(false);
	setTimeout(() => {
		setStudents([]);
	}, 200);
	
  }
  return (
	<Form id="myOffersForm">
		<Modal
			show={isLookingPostulations}
			size='xl'
			onHide={onModalHide}
			aria-labelledby="contained-modal-title-vcenter"
			className="myOffersModal"
		>
			<Modal.Title className="myOffersModalTitle"><h2>Postulantes</h2></Modal.Title>
			<Modal.Body>
				<StudentAccordion students={students} />
			</Modal.Body>
		</Modal>
		<Col md={10}>
			<Row>
			</Row>
			<Row>
			<Col md={4}>
				<div id='myOfferMapperDiv'>
				<OfferMapper 
					myOffers={true}
				/>
				</div> 
			</Col>
			<Col md={6}>
				{showingOffer.title == null ? (
				<div className="container"></div>
				) : (
				<div className="offerShowerDiv">
					<EnterpriseOfferShower
						offer={showingOffer}
						postulationsClick={postulationsClick}
						students={students}
						setStudents={setStudents}
						postulations={postulations}
						setPostulations={setPostulations}
						setShowSpinner={setShowSpinner}
						/>
				</div>
				)}
			</Col>
			</Row>
		</Col>
	</Form>
  )
}

export default MyOffers