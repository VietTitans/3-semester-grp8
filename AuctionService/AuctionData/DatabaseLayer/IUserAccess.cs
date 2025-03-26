using AuctionData.ModelLayer;

namespace AuctionData.DatabaseLayer
{

    public interface IUserAccess
    {

        User GetUserById(int id);
        List<User> GetUserAll();
        int CreateUser(User userToAdd);
        bool UpdateUser(User userToUpdate);
        bool DeleteUserById(int id);

    }
}
