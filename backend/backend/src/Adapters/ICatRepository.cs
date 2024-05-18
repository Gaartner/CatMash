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
    }
}