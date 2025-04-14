using AuctionData.Model;

namespace AuctionData.Service
{
    public interface IUserAccess
    {

        Task<List<User>?>? GetUsers(int id = -1);
        Task<int> SaveUser(User userToSave);

    }
}
