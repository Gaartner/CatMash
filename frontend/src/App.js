import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import HomePage from "./pages/Home/HomePage";
import ScoresPagePage from "./pages/Score/ScoresPage";
import VotePage from "./pages/Voting/VotePage";

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/score" element={<ScoresPagePage />} />
        <Route path="/vote" element={<VotePage />} />
      </Routes>
    </Router>
  );
}

export default App;
