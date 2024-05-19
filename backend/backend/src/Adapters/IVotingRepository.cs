using backend.Core;

namespace backend.Adapters
{
    /// <summary>
    /// Defines the methods for interacting with voting data for cats.
    /// </summary>
    public interface IVotingRepository
    {
        /// <summary>
        /// Adds a vote for the cat with the specified ID.
        /// </summary>
        /// <param name="catId">The unique identifier of the cat.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task VoteForCat(string id);
        

        /// <summary>
        /// Retrieves all cats ordered by their score in descending order.
        /// </summary>
        /// <returns>A list of all cats ordered by score.</returns>
        Task<List<Cat>> GetAllCatsOrderedByScore();

        /// <summary>
        /// Retrieves the details of the cat with the specified ID.
        /// </summary>
        /// <param name="catId">The unique identifier of the cat.</param>
        /// <returns>The cat details.</returns>
        Task<Cat> GetCatDetails(string catId);

        /// <summary>
        /// Adds a new cat with the specified details.
        /// </summary>
        /// <param name="cat">The cat to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task AddCat(Cat cat);
    }
}