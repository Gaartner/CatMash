using System.Threading.Tasks;
namespace CatMash;
{
    public interface IVotingService
    { 
        Task VoteForCat(int catId);
    }
}

