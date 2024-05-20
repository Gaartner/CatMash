import React from "react";
import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <nav>
      <ul>
        <li>
          <Link to="/">Home</Link>
        </li>
        <li>
          <Link to="/score">Score</Link>
        </li>
        <li>
          <Link to="/vote">Vote</Link>
        </li>
      </ul>
    </nav>
  );
};

// Styles CSS
const styles = `
nav {
  background-color: #f0f0f0;
  padding: 10px 0;
}
ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
  text-align: center;
}
li {
  display: inline;
  margin: 0 10px;
}
a {
  text-decoration: none;
  color: #333;
  font-weight: bold;
  padding: 5px 10px;
  border-radius: 5px;
  transition: background-color 0.3s ease;
}
a:hover {
  background-color: #ddd;
}
`;

// Appliquer les styles
const styleSheet = document.createElement("style");
styleSheet.type = "text/css";
styleSheet.innerText = styles;
document.head.appendChild(styleSheet);

export default Navbar;
