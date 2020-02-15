import React, { useEffect, useState } from "react";
import { api } from "../../services/api";
import { Card } from "../../components/card";
import { useFilter } from "../../context/food-list";

const List = () => {
  const [recipes, setRecipes] = useState([]);
  const { listFilter } = useFilter();
  useEffect(() => {
    async function getRecipes() {
      const response = await api.get("food", {
        params: {
          title_like: listFilter
        }
      });
      setRecipes(response.data);
    }
    getRecipes();
  }, [listFilter]);

  return (
    <>
      {recipes.map(recipe => (
        <Card key={recipe.id} {...recipe} />
      ))}
    </>
  );
};
export { List };
