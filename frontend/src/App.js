// src/App.js
import React from "react";
import { BrowserRouter as Router } from "react-router-dom";
import ScoresPage from "./pages/ScoresPage";
//import VotePage from "./pages/VotePage";

const App = () => {
  return (
    <Router>
      <ScoresPage />
    </Router>
  );
};

export default App;
