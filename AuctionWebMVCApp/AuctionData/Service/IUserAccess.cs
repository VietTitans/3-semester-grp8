using AuctionData.Model;

namespace AuctionData.Service
{
    public interface IUserAccess
    {
        Task<List<User>?> GetUsers(string tokenToUse, int id = -1);
        Task<int> SaveUser(string tokenToUse, User userToSave);
    }
}
