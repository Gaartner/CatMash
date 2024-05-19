using backend.Adapters;
using backend.Core;
using System.Threading.Tasks;

namespace backend.Services
{
    /// <summary>
    /// Service class for handling voting operations for cats.
    /// </summary>
    public class VotingService : IVotingService
    {
        private readonly IVotingRepository _votingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VotingService"/> class.
        /// </summary>
        /// <param name="votingRepository">The repository for interacting with voting data.</param>
        public VotingService(IVotingRepository votingRepository)
        {
            _votingRepository = votingRepository;
        }

        /// <summary>
        /// Votes for the cat with the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the cat to vote for.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task VoteForCat(string id)
        {
            await _votingRepository.VoteForCat(id);
        }
    }
}