import { Navigate } from "react-router-dom";
import { useAuth } from "./AuthContext";

export const OnLoggedHideRoute = ({ children }) => {
  const { token } = useAuth();
  if (token) {
    return <Navigate to="/Home" />;
  }
  return children;
};
