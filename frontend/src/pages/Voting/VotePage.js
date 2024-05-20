import React, { useEffect, useState } from "react";

const VotePage = () => {
  const [cats, setCats] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchInitialCats = async () => {
      try {
        const res1 = await fetch(
          "https://localhost:7114/api/CatControllers/Random"
        );
        const res2 = await fetch(
          "https://localhost:7114/api/CatControllers/Random"
        );

        if (!res1.ok || !res2.ok) {
          throw new Error("Failed to fetch data");
        }

        const cat1 = await res1.json();
        const cat2 = await res2.json();
        setCats([cat1, cat2]);
      } catch (error) {
        setError("Failed to fetch cats");
      }
    };

    fetchInitialCats();
  }, []);

  const handleVote = async (catId) => {
    try {
      const res = await fetch(`https://localhost:7114/api/Voting/${catId}`, {
        method: "POST",
      });

      if (!res.ok) {
        throw new Error(`Failed to vote for cat with ID ${catId}`);
      }

      const votedCat = cats.find((cat) => cat.id === catId);

      const newCatRes = await fetch(
        "https://localhost:7114/api/CatControllers/Random"
      );
      if (newCatRes.ok) {
        const newCat = await newCatRes.json();
        setCats((prevCats) => {
          const remainingCat = prevCats.find((cat) => cat.id !== catId);
          return remainingCat ? [votedCat, newCat] : [votedCat];
        });
      } else {
        setCats([votedCat]);
      }
    } catch (error) {
      setError(`Failed to vote for cat with ID ${catId}`);
    }
  };

  if (error) {
    return <div>Error: {error}</div>;
  }

  if (cats.length === 1) {
    return (
      <div>
        <h1>Vote for a Cat</h1>
        <p>
          Refresh the page or come back later to vote again. You've exhausted
          the database of cats.
        </p>
      </div>
    );
  }

  return (
    <main>
      <h1>Vote for a Cat</h1>
      <div style={{ display: "flex", justifyContent: "center", gap: "20px" }}>
        {cats.map((cat) => (
          <div
            key={cat.id}
            onClick={() => handleVote(cat.id)}
            style={{ cursor: "pointer" }}
          >
            <img src={cat.url} alt={`Cat ${cat.id}`} width="100" />
            <button
              onClick={(e) => {
                e.stopPropagation();
                handleVote(cat.id);
              }}
            >
              Vote
            </button>
          </div>
        ))}
      </div>
    </main>
  );
};

export default VotePage;
