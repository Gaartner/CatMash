namespace backend.Core
{
    public interface IVotingService
    { 
        Task VoteForCat(int catId);
    }
}

