import "./Button.css";

const Button = ({ btnText, value, color, type, onChange, disabled, onClick }) => {
  return (
    <button
      value={value}
      type={type}
      id="btn"
      style={{ background: color }}
      onChange={onChange}
      disabled={disabled}
      onClick={onClick}
    >
      {btnText}
    </button>
  );
};
export default Button;
