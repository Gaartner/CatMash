import React, { useEffect, useState } from "react";

const ScoresPage = () => {
  const [cats, setCats] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const res = await fetch(
          "https://localhost:7114/api/CatControllers/OrderedByVoteCount"
        );
        if (!res.ok) {
          throw new Error("Failed to fetch data");
        }
        const data = await res.json();
        setCats(data);
      } catch (error) {
        setError("Failed to fetch cats");
      }
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Error: {error}</div>;
  }

  return (
    <main>
      <h1>Cat Scores</h1>
      <ul>
        {cats.map((cat) => (
          <li key={cat.id}>
            <img src={cat.url} alt={`Cat ${cat.id}`} width="100" />
            <p>Score: {cat.score}</p>
          </li>
        ))}
      </ul>
    </main>
  );
};

export default ScoresPage;
