import "./TextInput.css"


const TextInput = ({ labelText, placeholderText, type, ref }) => {
  return (
    <div className="login-wrapper">
      <label id="label-input">{labelText}</label>
      <input id="txt-input" type={type} ref={ref} placeholder={placeholderText}></input>
    </div>
  );
};

export default TextInput;
