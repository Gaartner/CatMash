using System;
using System.Threading.Tasks;
using backend.Core;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    /// <summary>
    /// API controller for managing cat voting.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class VotingController : ControllerBase
    {
        private readonly IVotingService _votingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VotingController"/> class.
        /// </summary>
        /// <param name="votingService">The service for cat voting operations.</param>
        public VotingController(IVotingService votingService)
        {
            _votingService = votingService ?? throw new ArgumentNullException(nameof(votingService));
        }

        /// <summary>
        /// Votes for a cat with the specified ID.
        /// </summary>
        /// <param name="catId">The unique identifier of the cat to vote for.</param>
        /// <returns>An IActionResult indicating the result of the voting operation.</returns>
        [HttpPost("{catId}")]
        public async Task<IActionResult> VoteForCat(string catId)
        {
            try
            {
                await _votingService.VoteForCat(catId);
                return Ok($"Vote recorded for the cat with ID {catId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while voting for the cat with ID {catId}: {ex.Message}");
            }
        }
    }
}