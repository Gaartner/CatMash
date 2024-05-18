using backend.Core;
using backend.Utils;
using Newtonsoft.Json;

namespace backend.Adapters
{
    /// <summary>
    /// A repository for retrieving cat data from a JSON source.
    /// </summary>
    public class JsonCatRepository : ICatRepository
    {
        private readonly string _jsonUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonCatRepository"/> class.
        /// </summary>
        /// <param name="jsonUrl">The URL of the JSON file containing cat data.</param>
        public JsonCatRepository(string jsonUrl)
        {
            _jsonUrl = jsonUrl;
        }

        /// <summary>
        /// Retrieves all cats from the JSON file.
        /// </summary>
        /// <returns>A list of all cats.</returns>
        /// <exception cref="ApplicationException">Thrown when the retrieval of cats from the JSON file fails.</exception>
        public async Task<List<Cat>> GetAllCats()
        {
            try
            {
                using var httpClient = new HttpClient();
                string jsonContent = await httpClient.GetStringAsync(_jsonUrl);
                var jsonObject = JsonConvert.DeserializeObject<JsonResponseCat>(jsonContent);
                if (jsonObject?.Images != null)
                {
                    return jsonObject.Images;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve cats from JSON file.", ex);
            }
            return new List<Cat>();
        }

        public async Task<Cat> GetCatById(string id)
        {
            // This operation is not supported for this repository.
            throw new InvalidOperationException();
        }
        
        public async Task SaveCat(Cat cat)
        {
            // Saving cats is not supported in JSON storage.
            throw new NotSupportedException("Saving cats is not supported in JSON storage.");
        }
    }
}
