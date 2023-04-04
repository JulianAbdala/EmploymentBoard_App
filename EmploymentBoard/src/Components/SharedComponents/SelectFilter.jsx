import React from 'react'

import { Form } from 'react-bootstrap';



const SelectFilter = ({ setFilter, options }) => {

  const changeHandler = (e) => {
    setFilter(e.value);
  }

  return (
	<>
    <Form.Select onChange={changeHandler}>
      {options.map((option) => {
          return (
            <option>
              {option}
            </option>
          )
          })}
    </Form.Select>
  </>
  )
}

export default SelectFilter