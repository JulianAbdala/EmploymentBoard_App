import "./App.css";
import { Route, Routes, Navigate } from "react-router-dom";
import Navbar from "./Components/UI//Forms/Navbar";
import Footer from "./Components/UI//Forms/Footer";
import Home from "./pages/Home.jsx";
import CompanyHome from "./pages/CompanyHome/CompanyHome";
import Login from "./pages/Login.jsx";
import Profile from "./pages/Profile/Profile";
import Register from "./pages/Register.jsx";
import SavedJobs from "./pages/SavedJobs";
import AdminDashboard from "./pages/Admin/AdminDashboard";
import { OfferContextProvider } from "./context/OfferContext";
import { AuthProvider } from "./context/AuthContext/AuthContext";
import { ProtectedRoute } from "./context/AuthContext/ProtectedRoute";
import { OnLoggedHideRoute } from "./context/AuthContext/OnLoggedHideRoute";

const App = () => {
  return (
    <>
      <AuthProvider>
        <OfferContextProvider>
          <Navbar />
          <div className="div-wrapper">
            <Routes>
              <Route
                path="*"
                element={<Navigate replace to="/Login" />}
              ></Route>
              <Route
                path="/Home"
                element={
                  <ProtectedRoute>
                    <Home />
                  </ProtectedRoute>
                }
              ></Route>
              <Route
                path="/Login"
                element={
                  <OnLoggedHideRoute>
                    <Login />
                  </OnLoggedHideRoute>
                }
              ></Route>
              <Route
                path="/Profile"
                element={
                  <ProtectedRoute>
                    <Profile />
                  </ProtectedRoute>
                }
              ></Route>
              <Route
                path="/Register"
                element={
                  <OnLoggedHideRoute>
                    <Register />
                  </OnLoggedHideRoute>
                }
              ></Route>
              <Route 
                path="/InicioCompania"
                element= {
                  <ProtectedRoute>
                    <CompanyHome />
                  </ProtectedRoute>
              }
              />
              <Route
                path="/SavedJobs"
                element={
                  <ProtectedRoute>
                    <SavedJobs />
                  </ProtectedRoute>
                }
              ></Route>
              <Route 
                path="/AdminDashboard"
                element={
                  <ProtectedRoute>
                    <AdminDashboard />
                  </ProtectedRoute>
                }
              ></Route>
            </Routes>
          </div>
          <Footer />
        </OfferContextProvider>
      </AuthProvider>
    </>
  );
};

export default App;
