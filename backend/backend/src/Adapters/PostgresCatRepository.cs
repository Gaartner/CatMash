using System.Data;
using Dapper;
using backend.Core;

namespace backend.Adapters
{
    /// <summary>
    /// A repository for interacting with cat data in a PostgreSQL database.
    /// </summary>
    public class PostgresCatRepository : ICatRepository
    {
        private readonly IDbConnection _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgresCatRepository"/> class.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        public PostgresCatRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Updates the score of a cat in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the cat.</param>
        /// <param name="newScore">The new score to be assigned to the cat.</param>
        /// <exception cref="ApplicationException">Thrown when the update operation fails.</exception>
        public async Task UpdateCatScore(int id, int newScore)
        {
            try
            {
                string query = "UPDATE \"Cats\" SET \"Score\" = @NewScore WHERE \"Id\" = @Id";
                await _connection.ExecuteAsync(query, new { Id = id, NewScore = newScore });
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to update score for cat with ID {id} in PostgreSQL database.", ex);
            }
        }

        /// <summary>
        /// Retrieves all cats from the database.
        /// </summary>
        /// <returns>A list of all cats.</returns>
        /// <exception cref="ApplicationException">Thrown when the retrieval operation fails.</exception>
        public async Task<List<Cat>> GetAllCats()
        {
            try
            {
                string query = "SELECT * FROM \"Cats\"";
                var result = await _connection.QueryAsync<Cat>(query);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve cats from PostgreSQL database.", ex);
            }
        }

        /// <summary>
        /// Retrieves a cat by its unique identifier from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the cat.</param>
        /// <returns>The cat with the specified identifier.</returns>
        /// <exception cref="ApplicationException">Thrown when the retrieval operation fails.</exception>
        public async Task<Cat> GetCatById(string id)
        {
            try
            {
                string query = "SELECT * FROM \"Cats\" WHERE \"Id\" = @Id";
                var result = await _connection.QueryFirstOrDefaultAsync<Cat>(query, new { Id = id });
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Failed to retrieve cat with ID {id} from PostgreSQL database.", ex);
            }
        }

        /// <summary>
        /// Saves a cat to the database. If the cat already exists, it updates the existing record.
        /// </summary>
        /// <param name="cat">The cat to save.</param>
        /// <exception cref="ApplicationException">Thrown when the save operation fails.</exception>
        public async Task SaveCat(Cat cat)
        {
            try
            {
                string query = @"
                INSERT INTO ""Cats"" (""Id"", ""Url"", ""Score"") 
                VALUES (@Id, @Url, @Score) 
                ON CONFLICT (""Id"") DO UPDATE 
                SET ""Url"" = EXCLUDED.""Url"", ""Score"" = EXCLUDED.""Score""";
                await _connection.ExecuteAsync(query, new { Id = cat.Id, Url = cat.Url, Score = cat.Score });
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to save cat to PostgreSQL database.", ex);
            }
        }

        // Additional methods for adding a new cat and deleting a cat will be implemented as needed.
    }
}
