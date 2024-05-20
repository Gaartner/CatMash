import React, { useEffect, useState } from "react";
import axios from "axios";
import endpoints from "../../utils/endpoints";

const CatPage = () => {
  const [cats, setCats] = useState([]);

  useEffect(() => {
    const fetchCats = async () => {
      try {
        const response = await axios.get(
          `${endpoints.catApi}CatControllers/OrderedByVoteCount`
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
