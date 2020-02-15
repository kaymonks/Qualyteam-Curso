import React from "react";
import { Link } from "react-router-dom";
import logo from "../logo.png";
import { useFilter } from "../context/food-list";

const Navbar = () => {
  const { setListFilter } = useFilter();

  return (
    <nav className="navbar">
      <Link to="/" className="navbar--logo-container">
        <figure className="">
          <img src={logo} alt="Uma imagem impressionante" />
        </figure>
      </Link>
      <div className="navbar--center-container">
        <input
          role="search"
          placeholder="Procure uma receita"
          aria-labelledby="search"
          onChange={e => setListFilter(e.target.value)}
        />
      </div>
      <div className="navbar--right-container">
        <Link to="/food/create" className="button--plus">
          +
        </Link>
      </div>
    </nav>
  );
};

export { Navbar };
