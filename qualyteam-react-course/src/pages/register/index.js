import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { Button } from "../../components/button";
import { api } from "../../services/api";

const Register = () => {
  const [title, setTitle] = useState("");
  const [imageUrl, setImgUrl] = useState("");
  const [ingredients, setIngredients] = useState("");
  const [description, setDescription] = useState("");
  const [preparation, setPreparation] = useState("");
  const history = useHistory();

  async function handleSubmit(e) {
    e.preventDefault();
    await api.post("food", {
      title,
      imgUrl: imageUrl,
      ingredients,
      description,
      preparation
    });
    history.push("/");
  }

  return (
    <div className="register">
      <h1>Nova receita</h1>
      <div className="register--container">
        <form className="register--container--form" onSubmit={handleSubmit}>
          <div className="register--container--side">
            <div className="form-group">
              <label htmlFor="title">Title</label>
              <input id="title" onChange={e => setTitle(e.target.value)} />
            </div>
            <div className="form-group">
              <label htmlFor="image">Imagem (URL)</label>
              <input id="image" onChange={e => setImgUrl(e.target.value)} />
            </div>
            <div className="form-group">
              <label htmlFor="ingredients">Ingredientes</label>
              <textarea
                id="ingredients"
                onChange={e => setIngredients(e.target.value)}
              />
            </div>
          </div>
          <div className="register--container--side">
            <div className="form-group">
              <label htmlFor="description">Descrição</label>
              <textarea
                id="description"
                onChange={e => setDescription(e.target.value)}
              />
            </div>

            <div className="form-group">
              <label htmlFor="preparation">Método de preparo</label>
              <textarea
                id="preparation"
                onChange={e => setPreparation(e.target.value)}
              />
            </div>
          </div>
          <Button htmlType="submit">Create</Button>
        </form>
      </div>
    </div>
  );
};

export { Register };
