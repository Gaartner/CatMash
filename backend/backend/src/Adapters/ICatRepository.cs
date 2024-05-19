using backend.Core;

namespace backend.Adapters
{
    /// <summary>
    /// Defines the methods for interacting with cat data.
    /// </summary>
    public interface ICatRepository
    {
        /// <summary>
        /// Retrieves all cats.
        /// </summary>
        /// <returns>A list of all cats.</returns>
        Task<List<Cat>> GetAllCats();

        /// <summary>
        /// Retrieves a cat by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the cat.</param>
        /// <returns>The cat with the specified identifier.</returns>
        Task<Cat> GetCatById(string id);

        /// <summary>
        /// Saves the given cat.
        /// </summary>
        /// <param name="cat">The cat to save.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SaveCat(Cat cat);

        /// <summary>
        /// Updates the vote count of the specified cat.
        /// </summary>
        /// <param name="catId">The unique identifier of the cat whose vote count to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateCatVoteCount(string catId);
        
        /// <summary>
        /// Retrieves all cats ordered by their vote count.
        /// </summary>
        /// <returns>A list of cats ordered by their vote count.</returns>
        Task<List<Cat>> GetAllCatsOrderedByVoteCount();
    }
}