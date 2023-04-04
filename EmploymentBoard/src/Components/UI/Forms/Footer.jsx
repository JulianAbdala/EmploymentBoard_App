import React from "react";
import "./Footer.css";
import Logo from "../imgs/logoutn.png";
const Footer = () => {
  return (
    <div className="footer-wrapper">
      <hr className="divisor" />
      <footer className="Footer">
        <img className="imageWrapper" src={Logo} alt="logo" />

        <div>
          <p className="wrapper">FACULTAD REGIONAL ROSARIO</p>
          <p className="wrapper">
            Contacto: Zeballos 1341 - Rosario. Telefono: 0341-4481871
          </p>
        </div>
      </footer>
    </div>
  );
};

export default Footer;
