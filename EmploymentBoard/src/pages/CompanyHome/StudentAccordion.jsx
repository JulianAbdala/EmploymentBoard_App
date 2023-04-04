import React, {useEffect, useState} from 'react';
import { Accordion, Spinner } from 'react-bootstrap';
import StudentAccordionItem from './StudentAccordionItem';
import "./StudentAccordion.css"


const StudentAccordion = ({ students }) => {
	const [studentsMapped, setStudentsMapped] = useState(null)
	const [showSpinner, setShowSpinner] = useState(true);

	const spinner = (
		<Spinner animation="border" role="status" variant="light" className="spinnerStudentAccordion">
			<span className="visually-hidden">Loading...</span>
		</Spinner>
	)
	useEffect(() => {
		if (students.length !== 0) {
			setShowSpinner(false);
			setStudentsMapped(students?.map((student, index) => {
				return (
					<StudentAccordionItem 
						index={index}
						name={student.name}
						lastName={student.lastName}
						studentId={student.studentId}
						careerName={student.careerName}
						email={student.email}
					/>
				);
			}));
		}
	  }, [students]);

    return (
		<Accordion className="studentAccordion">
			{ showSpinner ? spinner : students.length === 0 ? <h1 className="studAccordionH1">No hay postulaciones para esta oferta</h1> : studentsMapped}
		</Accordion>
    );
  };
  
  export default StudentAccordion;