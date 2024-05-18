using backend.Core;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    /// <summary>
    /// API controller for managing cat data.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CatControllers : ControllerBase
    {
        private readonly ICatService _catService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatControllers"/> class.
        /// </summary>
        /// <param name="catService">The service to interact with cat data.</param>
        public CatControllers(ICatService catService)
        {
            _catService = catService;
        }

        /// <summary>
        /// Retrieves all cats.
        /// </summary>
        /// <returns>A list of all cats.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCats()
        {
            try
            {
                var cats = await _catService.GetAllCats();
                return Ok(cats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve cats: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a cat by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the cat.</param>
        /// <returns>The cat with the specified identifier.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCatById(string id)
        {
            try
            {
                var cat = await _catService.GetCatById(id);
                if (cat == null)
                {
                    return NotFound();
                }
                return Ok(cat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to retrieve cat with ID {id}: {ex.Message}");
            }
        }
        
        /// <summary>
        /// Retrieves a random cat.
        /// </summary>
        /// <returns>A random cat.</returns>
        [HttpGet("Random")]
        public async Task<IActionResult> GetRandomCat()
        {
            var randomCat = await _catService.GetRandomCat();
            if (randomCat == null)
            {
                return NotFound();
            }
            return Ok(randomCat);
        }
    }
}
