import React from "react";
import { Button } from "../../components/button";
import logo from "../../logo.png";

const Login = () => (
  <div className="login">
      <figure>
          <img src={logo} alt="recipes" />
      </figure>
    <form className="login--form">
      <div className="login--form--inputscontainer">
        <div className="form-group">
            <label htmlFor="email">E-mail</label>
            <input id="email" name="email" />
        </div>
        <div className="form-group">
            <label htmlFor="password">Password</label>
            <input id="password" name="password" />
        </div>
      </div>
      
        <Button> Entrar </Button>
    </form>
  </div>
);

export { Login };
