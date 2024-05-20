import React, { useEffect, useState } from "react";
import axios from "axios";

const CatPage = () => {
  const [cats, setCats] = useState([]);

  useEffect(() => {
    const fetchCats = async () => {
      try {
        const response = await axios.get(
          "https://localhost:7114/api/CatControllers/OrderedByVoteCount"
        );
        setCats(response.data);
      } catch (error) {
        console.error("Failed to fetch cats:", error);
      }
    };

    fetchCats();
  }, []);

  return (
    <div>
      <h1>Cat Scores</h1>
      <ul>
        {cats.map((cat) => (
          <li key={cat.id}>
            <img src={cat.url} alt={`Cat ${cat.id}`} width="100" />
            <p>Score: {cat.score}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default CatPage;
