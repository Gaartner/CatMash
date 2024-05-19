using backend.Adapters;
using backend.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    /// <summary>
    /// Service class for managing cat-related operations.
    /// </summary>
    public class CatService : ICatService
    {
        private readonly ICatRepository _catRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatService"/> class.
        /// </summary>
        /// <param name="catRepository">The repository for interacting with cat data.</param>
        public CatService(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        /// <summary>
        /// Retrieves all cats.
        /// </summary>
        /// <returns>A collection of all cats.</returns>
        public async Task<IEnumerable<Cat>> GetAllCats()
        {
            return await _catRepository.GetAllCats();
        }

        /// <summary>
        /// Retrieves a random cat.
        /// </summary>
        /// <returns>A random cat.</returns>
        /// <exception cref="InvalidOperationException">Thrown when there are no cats available.</exception>
        public async Task<Cat> GetRandomCat()
        {
            var cats = await _catRepository.GetAllCats();
            if (cats.Any())
            {
                var randomIndex = new Random().Next(0, cats.Count);
                return cats[randomIndex];
            }
            else
            {
                throw new InvalidOperationException("No cats available.");
            }
        }

        /// <summary>
        /// Retrieves a cat by its unique identifier.
        /// </summary>
        /// <param name="catId">The unique identifier of the cat.</param>
        /// <returns>The cat with the specified identifier.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the cat with the specified ID is not found.</exception>
        public async Task<Cat> GetCatById(string catId)
        {
            var cat = await _catRepository.GetCatById(catId);
            return cat ?? throw new InvalidOperationException("Cat not found with the specified ID.");
        }

        /// <summary>
        /// Retrieves all cats ordered by their vote count.
        /// </summary>
        /// <returns>A list of cats ordered by their vote count.</returns>
        /// <exception cref="ApplicationException">Thrown when the operation fails to retrieve cats ordered by vote count.</exception>
        public async Task<List<Cat>> GetAllCatsOrderedByVoteCount()
        {
            try
            {
                return await _catRepository.GetAllCatsOrderedByVoteCount();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve cats ordered by vote count.", ex);
            }
        }
    }
}
