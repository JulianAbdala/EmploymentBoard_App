import React, { useState } from "react";

const OfferContext = React.createContext();

export function OfferContextProvider({ children }) {
  const [showingOffer, setShowingOffer] = useState({});
  return (
    <OfferContext.Provider value={{ showingOffer, setShowingOffer }}>
      {children}
    </OfferContext.Provider>
  );
}

export default OfferContext;
