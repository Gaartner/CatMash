"use client";

import React, { useState, useEffect } from "react";

// Interface to describe the structure of cat data
interface Cat {
  id: string;
  url: string;
  score: number;
}

// Function to fetch cat data from the API
async function getData(): Promise<Cat[]> {
  const res = await fetch(
    "https://localhost:7114/api/CatControllers/OrderedByVoteCount"
  );

  if (!res.ok) {
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

// Component for displaying the list of cats
const pageBoard: React.FC = () => {
  // State to store cat data
  const [cats, setCats] = useState<Cat[]>([]);
  // State to handle errors in fetching data
  const [error, setError] = useState<string | null>(null);

  // Effect to fetch cat data when the component loads
  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getData();
        setCats(data);
      } catch (error) {
        setError("Failed to fetch cats");
      }
    };

    fetchData();
  }, []);

  // Conditional rendering in case of an error fetching data
  if (error) {
    return <div>Error: {error}</div>;
  }

  // Rendering the list of cats if data was successfully fetched
  return (
    <main>
      <h1>All Cats</h1>
      <ul>
        {cats.map((cat) => (
          <li key={cat.id}>
            {cat.id} {cat.url} {cat.score}
          </li>
        ))}
      </ul>
    </main>
  );
};

export default pageBoard;
