namespace backend.Core
{
    /// <summary>
    /// Defines the methods for voting for a cat.
    /// </summary>
    public interface IVotingService
    { 
        /// <summary>
        /// Records a vote for the cat with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the cat.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task VoteForCat(string id);
    }
}