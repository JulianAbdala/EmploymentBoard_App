import "./Button.css";

const SmallButton = ({ btnText, value, color, type, onChange, disabled, onClick }) => {
  return (
    <button
      value={value}
      type={type}
      id="smallBtn"
      style={{ background: color }}
      onChange={onChange}
      disabled={disabled}
      onClick={onClick}
    >
      {btnText}
    </button>
  );
};
export default SmallButton;
