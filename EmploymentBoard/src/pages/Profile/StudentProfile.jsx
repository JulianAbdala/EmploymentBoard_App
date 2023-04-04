import { useState } from "react";
import StudentAppliedJobs from "./StudentAppliedJobs";

import StudentPersonalInfo from "./StudentPersonalInfo";
import StudentSkills from "./StudentSkills";

const StudentProfile = () => {
  const [active, setActive] = useState("studentInfo");

  const handleActive = (e) => {
    setActive(e.target.value);
  };

  return (
    <>
      <ul class="nav nav-tabs">
        <li class="nav-item">
          <button
            class="nav-link"
            onClick={handleActive}
            value="studentInfo"
          >
            Información personal
          </button>
        </li>
        <li class="nav-item">
          <button class="nav-link" onClick={handleActive} value="studentPostulation">
            Mis postulaciones
          </button>
        </li>
        <li class="nav-item">
          <button class="nav-link" onClick={handleActive} value="studentSkills">
            Mis conocimientos
          </button>
        </li>
      </ul>
      {active === "studentInfo" && <StudentPersonalInfo />}
      {active === "studentPostulation" && <StudentAppliedJobs />}
      {active === "studentSkills" && <StudentSkills />}
    </>
  );
};

export default StudentProfile;
