using backend.Adapters;
using backend.Core;

namespace backend.Services
{
    /// <summary>
    /// Service class responsible for handling operations related to cats.
    /// </summary>
    public class CatService : ICatService
    {
        private readonly ICatRepository _catRepository;
        private readonly List<Cat> _allCats = new List<Cat>();
        private bool _isLoaded = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatService"/> class with the specified cat repository.
        /// </summary>
        /// <param name="catRepository">The cat repository to be used.</param>
        public CatService(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        /// <summary>
        /// Retrieves all cats from the repository asynchronously.
        /// </summary>
        /// <returns>A collection of cats.</returns>
        public async Task<IEnumerable<Cat>> GetAllCats()
        {
            if (!_isLoaded)
            {
                await LoadCatsAsync();
                _isLoaded = true;
            }
            return _allCats;
        }

        /// <summary>
        /// Asynchronously loads cats from the repository.
        /// </summary>
        private async Task LoadCatsAsync()
        {
            var cats = await _catRepository.GetAllCats();
            _allCats.AddRange(cats);
        }

        /// <summary>
        /// Retrieves a random cat asynchronously.
        /// </summary>
        /// <returns>A random cat.</returns>
        public async Task<Cat> GetRandomCat()
        {
            if (!_isLoaded)
            {
                await LoadCatsAsync();
                _isLoaded = true;
            }

            if (_allCats.Any())
            {
                var randomIndex = new Random().Next(0, _allCats.Count);
                var randomCat = _allCats[randomIndex];
                _allCats.RemoveAt(randomIndex);
                return randomCat;
            }
            else
            {
                throw new InvalidOperationException("No cats available.");
            }
        }

        /// <summary>
        /// Retrieves a cat by its ID asynchronously.
        /// </summary>
        /// <param name="catId">The ID of the cat to retrieve.</param>
        /// <returns>The cat with the specified ID.</returns>
        public async Task<Cat> GetCatById(string catId)
        {
            if (!_isLoaded)
            {
                await LoadCatsAsync();
                _isLoaded = true;
            }

            if (_allCats.Count == 0)
            {
                throw new InvalidOperationException("No cats found in the repository.");
            }

            var cat = _allCats.FirstOrDefault(cat => cat.Id == catId);
            return cat != null ? cat : throw new InvalidOperationException("Cat not found with the specified ID.");
        }
    }
}
