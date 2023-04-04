import { createContext, useContext, useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useLocalStorage } from "./useLocalStorage";
import jwtDecode from "jwt-decode";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [token, setToken] = useLocalStorage("accessToken", null);
  const [userId, setUserId] = useState("");
  const [userEmail, setUserEmail] = useState("");
  const [userRole, setUserRole] = useLocalStorage("role", null);
  const [userDetails, setUserDetails] = useLocalStorage("userData", null);
  const [loginError, setLoginError] = useState(false);
  const navigate = useNavigate();

  const login = async (credentials) => {
    return fetch("https://localhost:7264/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(credentials),
    })
      .then((res) => {
        if (!res.ok) throw new Error(res.status);
        else return res.json();
      })
      .then((res) => {
        setToken(res);
        const tokenToDecode = localStorage.getItem("accessToken");
        const userData = jwtDecode(tokenToDecode);
        setUserId(userData.sub);
        setUserEmail(
          userData[
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
          ]
        );
        setUserRole(
          userData[
            "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
          ]
        );
      })
      .catch((err) => {
        console.log("error: " + err);
      });
  };

  // Cerrar sesion hace null la siguiente info y navega a /login
  const logout = () => {
    setToken(null);
    setUserId("");
    setUserEmail("");
    setUserRole(null);
    setUserDetails(null);
    localStorage.removeItem("userData");
    navigate("/", { replace: true });
  };

  const getUserData = () => {
    const headers = { "Content-Type": "application/json" };
    if (token) {
      headers["Authorization"] = `Bearer ${token["accessToken"]}`;
    }
    if (userRole === "Student") {
      fetch("https://localhost:7264/api/students/student", { headers })
        .then((response) => response.json())
        .then((data) => setUserDetails(data));
    }
    if (userRole === "Enterprise") {
      fetch("https://localhost:7264/api/enterprises/enterprise", { headers })
        .then((response) => response.json())
        .then((data) => setUserDetails(data));
    }
  };

  useEffect(() => {
    const headers = { "Content-Type": "application/json" };
    if (token) {
      headers["Authorization"] = `Bearer ${token["accessToken"]}`;
    }
    if (userRole === "Student") {
      fetch("https://localhost:7264/api/students/student", { headers })
        .then((response) => response.json())
        .then((data) => setUserDetails(data));
    } else if (userRole === "Enterprise") {
      fetch("https://localhost:7264/api/enterprises/enterprise", { headers })
        .then((response) => response.json())
        .then((data) => setUserDetails(data));
    } else {
      setUserDetails("");
    }
  }, [ token, userRole ]);

  const values = {
    token,
    login,
    logout,
    userId,
    userEmail,
    userRole,
    loginError,
    setLoginError,
    userDetails,
    setUserDetails,
    getUserData,
  };

  return <AuthContext.Provider value={values}>{children}</AuthContext.Provider>;
};

export const useAuth = () => {
  return useContext(AuthContext);
};
