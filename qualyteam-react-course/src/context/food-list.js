import React, { useContext, useState } from "react";

const ListFilterContext = React.createContext();

const ListFilterProvider = ({ children }) => {
  const [listFilter, setListFilter] = useState("");

  return (
    <ListFilterContext.Provider value={{ listFilter, setListFilter }}>
      {children}
    </ListFilterContext.Provider>
  );
};

const useFilter = () => {
  const context = useContext(ListFilterContext);

  if (context === undefined) {
    throw new Error("useFilter must be used within a ListFilterProvider");
  }
  return context;
};

export { ListFilterProvider, useFilter };
