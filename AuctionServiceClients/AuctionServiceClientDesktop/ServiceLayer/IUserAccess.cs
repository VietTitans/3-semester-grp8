using AuctionServiceClientDesktop.ModelLayer;

namespace AuctionServiceClientDesktop.Servicelayer
{
    public interface IUserAccess
    {

        Task<List<User>?>? GetUsers(int id = -1);
        Task<int> SaveUser(User userToSave);

    }
}
