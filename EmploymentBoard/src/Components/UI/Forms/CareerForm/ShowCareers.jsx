import React, { useState } from "react";
import Select from "react-select";
import { useAuth } from '../../../../context/AuthContext/AuthContext';
import "./ShowCareers.css";

const ShowCareers = ({ id, careerName, careerType, setShow, careers, setCareerInfo, careerInfo }) => {

    const { token } = useAuth();
    const [isEditing, setIsEditing] = useState(false);

    const handleInput = (e) => {
        setCareerInfo({
            ...careerInfo,
            [e.target.name]: e.target.value,
        });
    };


    const deleteCareer = async (e) => {
        e.preventDefault();
        fetch(`https://localhost:7264/api/careers/${id}`, {
          method: "DELETE",
          headers: {
            "Content-type": "application/json; charset=UTF-8",
            Authorization: `Bearer ${token["accessToken"]}`,
          },
        }).then((res) => {
          res.json();
          setShow(true);
        })
        .catch((err) => {
          console.log(err.message);
        });
      };

    const editCareer = (e) => {
        e.preventDefault();
        fetch(`https://localhost:7264/api/careers/${id}`, {
            method: "PUT",
            headers: {
                "Content-type": "application/json; charset=UTF-8",
                Authorization: `Bearer ${token["accessToken"]}`,
            },
            body: JSON.stringify({
                careerName: careerInfo.careerName,
                careerType: careerInfo.careerType,
            }),
        }).then((res) => {
            res.json();
            setShow(true);
            setIsEditing(false);
        });
    };

    if(id !== 2) {
    return (
        <tbody className="career-body">
            {isEditing ? (
                <tr>
                    <td>
                    <input
                        onChange={handleInput}
                        value={careerInfo.careerName}
                        className="txt-career-input"
                        name="careerName"
                        type="text"
                        id="careerName"
                    />
                    </td>
                    <td>
                    <Select
                        className="select-career"
                        options = {careers}
                        onChange={(e) => setCareerInfo({...careerInfo, careerType: e.value})}
                    />
                    </td>
                    <td>
                        <button className="btn btn-success" onClick={editCareer}>Guardar</button>
                        <button className="btn btn-danger" onClick={() => setIsEditing(false)}>Cancelar</button>
                    </td>
                </tr>
            ) : (
            <tr>
                <td>{careerName}</td>
                <td>{careerType}</td>
                <td>
                    <button type="button" className="btn btn-outline-success ms-2 me-3" onClick={() => setIsEditing(true)}>Editar</button>
                    <button type="button" className="btn btn-outline-danger me-3" onClick={deleteCareer}>Borrar</button>
                </td>
            </tr>
            )}
        </tbody>
    );
    };
};

export default ShowCareers;