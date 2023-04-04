import "./Home.css";  
import { useAuth } from "../context/AuthContext/AuthContext";
import AccountStatusPage from "./AccountStatus/AccountStatusPage";
import CompanyHome from "./CompanyHome/CompanyHome";
import ShowOffers from "./ShowOffers/ShowOffers";
import AdminDashboard from "./Admin/AdminDashboard";

const Home = () => {
  const { userRole, userDetails } = useAuth();

  return (
    <div className="home">
      {userDetails.accountStatus === 0 && userRole === "Student" && <ShowOffers />}
      {userDetails.accountStatus === 0 && userRole === "Enterprise" && <CompanyHome />}
      {userRole === "SuperAdmin" && <AdminDashboard />}
      {userDetails.accountStatus === 2 && (
        <AccountStatusPage
          message={"La aprobación de su cuenta se encuentra pendiente."}
        />
      )}
      {userDetails.accountStatus === 1 && (
        <AccountStatusPage
          message={
            "La aprobación de su cuenta fue rechazada. Comuníquese con Administración para más detalles."
          }
        />
      )}
    </div>
  );
};

export default Home;
