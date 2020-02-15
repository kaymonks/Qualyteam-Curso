import React, { Fragment } from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import "./App.scss";
import { Navbar } from "./components/navbar";
import { Login } from "./pages/login";
import { Register } from "./pages/register";
import { List } from "./pages/list";
import { Recipe } from "./components/Recipe";
import { ListFilterProvider } from "./context/food-list";

function App() {
  return (
    <Router>
      <ListFilterProvider>
        <div className="app">
          {true ? (
            <Fragment>
              <Navbar />
              <main className="content--container">
                <Switch>
                  <Route path="/" exact>
                    <List />
                  </Route>
                  <Route path="/food/details/:id" exact>
                    <Recipe />
                  </Route>
                  <Route path="/food/create" exact>
                    <Register />
                  </Route>
                </Switch>
              </main>
            </Fragment>
          ) : (
            <Login />
          )}
        </div>
      </ListFilterProvider>
    </Router>
  );
}

export default App;
