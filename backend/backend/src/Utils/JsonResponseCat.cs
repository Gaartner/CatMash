using backend.Core;
using Newtonsoft.Json;

namespace backend.Utils
{
    /// <summary>
    /// Represents a JSON response containing a list of cat images.
    /// </summary>
    public class JsonResponseCat
    {
        [JsonProperty("images")]
        public List<Cat> Images { get; set; }
    }
}