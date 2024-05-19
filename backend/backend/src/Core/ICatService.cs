namespace backend.Core
{
    /// <summary>
    /// Defines the methods for interacting with cat data.
    /// </summary>
    public interface ICatService
    {
        /// <summary>
        /// Retrieves all cats.
        /// </summary>
        /// <returns>A collection of all cats.</returns>
        Task<IEnumerable<Cat>> GetAllCats();

        /// <summary>
        /// Retrieves a random cat.
        /// </summary>
        /// <returns>A random cat.</returns>
        Task<Cat> GetRandomCat();

        /// <summary>
        /// Retrieves a cat by its unique identifier.
        /// </summary>
        /// <param name="catId">The unique identifier of the cat.</param>
        /// <returns>The cat with the specified identifier.</returns>
        Task<Cat> GetCatById(string catId);

        /// <summary>
        /// Retrieves all cats ordered by their vote count.
        /// </summary>
        /// <returns>A list of cats ordered by their vote count.</returns>
        Task<List<Cat>> GetAllCatsOrderedByVoteCount();
    }
}