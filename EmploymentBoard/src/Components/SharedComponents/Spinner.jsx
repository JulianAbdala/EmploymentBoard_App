import "./Spinner.css";
import { useNavigate } from "react-router-dom";

export default function Spinner( {route}) {
  const navigate = useNavigate();

  setTimeout(() => {
    navigate({route}, { replace: true });
  }, 4500);

  return <div class="lds-dual-ring"></div>;
}
