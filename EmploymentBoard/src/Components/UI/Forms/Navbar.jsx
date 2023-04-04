import React, { useContext } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../../context/AuthContext/AuthContext";
import "./Navbar.css";
import Logo from "../imgs/logoutn.png";
import OfferContext from "../../../context/OfferContext";


const Navbar = () => {
  const { logout, token, userRole, userDetails } = useAuth();
  const navigate = useNavigate();
  const { setShowingOffer } = useContext(OfferContext);


  const handleLogout = () => {
    logout();
    navigate("/Login");
    setShowingOffer({});
  };

  return (
    <nav className="navbar navbar-expand-lg navbar-dark">
      <div className="container-fluid">
        <div className="navbar-brand">
          <Link to="/Home">
            {" "}
            <img width="170px" height="50%" src={Logo} alt="logo-utn" />
          </Link>
        </div>
        <div className="" id="navbarNav">
          <ul className="navbar-nav">
            {token &&
              userDetails.accountStatus === 0 &&
              (userRole === "Student" || userRole === "Enterprise") && (
                <li className="nav-item">
                  <Link className="nav-link" to="/Profile">
                    Perfil
                  </Link>
                </li>
              )}
            {token ? (
              <>
                <li className="nav-item">
                  <Link className="nav-link" to="/Home">
                    Inicio
                  </Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" onClick={handleLogout} to="/Login">
                    Salir
                  </Link>
                </li>
              </>
            ) : (
              <>
                <li className="nav-item">
                  <Link className="nav-link" to="/Login">
                    Ingresar
                  </Link>
                </li>
                <li className="nav-item">
                  <Link className="nav-link" aria-current="page" to="/register">
                    Registrarse
                  </Link>
                </li>
              </>
            )}
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
