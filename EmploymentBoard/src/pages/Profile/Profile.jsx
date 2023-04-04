import React from "react";
import { useAuth } from "../../context/AuthContext/AuthContext";
import EnterpriseProfile from "./EnterpriseProfile";
import StudentProfile from "./StudentProfile";

const Profile = () => {
  const { userRole, userDetails } = useAuth();
  const accepted = userDetails.accountStatus === 0 

  return (
    <div>
      {accepted && userRole === "Student" && (
        <StudentProfile />
      )}
      {accepted && userRole === "Enterprise" && (
        <EnterpriseProfile />
      )}

    </div>
  );
};

export default Profile;
