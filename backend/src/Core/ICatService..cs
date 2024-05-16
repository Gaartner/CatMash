using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatMash;
{
    public interface ICatService_
    {
        Task<IEnumerable<Cat>> GetCats();
        Task<Cat> GetCatById(int catId);
    }
}
