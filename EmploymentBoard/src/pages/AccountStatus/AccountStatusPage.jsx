import React from "react";
import "./AccountStatusPage.css";
const AccountStatusPage = ({ message }) => {
  return (
    <div className="status-cont">
      <h3>{message}</h3>
    </div>
  );
};

export default AccountStatusPage;
