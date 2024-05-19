using backend.Core;

namespace backend.Adapters
{
    /// <summary>
    /// Represents a repository for handling voting operations and retrieving cat data.
    /// </summary>
    public class VotingRepository : IVotingRepository
    {
        private readonly ICatRepository _catRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VotingRepository"/> class with the specified cat repository.
        /// </summary>
        /// <param name="catRepository">The cat repository.</param>
        public VotingRepository(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        /// <summary>
        /// Votes for the specified cat by updating its vote count in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the cat.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task VoteForCat(string id)
        {
            await _catRepository.UpdateCatVoteCount(id);
        }

        /// <summary>
        /// Retrieves all cats from the database ordered by their score.
        /// </summary>
        /// <returns>A list of all cats ordered by their score.</returns>
        public async Task<List<Cat>> GetAllCatsOrderedByScore()
        {
            return await _catRepository.GetAllCatsOrderedByVoteCount();
        }

        /// <summary>
        /// Retrieves the details of a cat with the specified ID from the database.
        /// </summary>
        /// <param name="id">The unique identifier of the cat.</param>
        /// <returns>The details of the cat with the specified ID.</returns>
        public async Task<Cat> GetCatDetails(string Id)
        {
            return await _catRepository.GetCatById(Id);
        }

        /// <summary>
        /// Adds a new cat to the database.
        /// </summary>
        /// <param name="cat">The cat to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddCat(Cat cat)
        {
            await _catRepository.SaveCat(cat);
        }
    }
}