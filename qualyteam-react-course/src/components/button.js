import React from "react";

const Button = ({ children, htmlType, onClick: handleClick }) => (
  <button className="primary-button" type={htmlType} onClick={handleClick}>
    {children}
  </button>
);

export { Button };
