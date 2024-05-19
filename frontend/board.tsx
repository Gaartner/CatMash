interface Cat {
  id: string;
  url: string;
  score: number;
}

async function getData(): Promise<Cat[]> {
  const res = await fetch("https://localhost:7114/api/CatControllers");

  if (!res.ok) {
    throw new Error("Failed to fetch data");
  }

  return res.json();
}

export default async function Board() {
  const data = await getData();

  return (
    <main>
      <h1>All Cats</h1>
      <ul>
        {data.map((cat) => (
          <li key={cat.id}>
            {cat.url}
            {cat.score}
          </li>
        ))}
      </ul>
    </main>
  );
}
