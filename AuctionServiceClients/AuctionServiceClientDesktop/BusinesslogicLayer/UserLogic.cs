using AuctionServiceClientDesktop.ModelLayer;
using AuctionServiceClientDesktop.Servicelayer;
using AuctionServiceClientDesktop.ServiceLayer;

namespace AuctionServiceClientDesktop.ControlLayer
{
    public class UserLogic
    {

        readonly IUserAccess _pAccess;

        public UserLogic()
        {
            _pAccess = new UserServiceAccess();
        }

        public async Task<List<User>?> GetAllUsers()
        {
            List<User>? foundUsers = null;
            if (_pAccess != null)
            {
                foundUsers = await _pAccess.GetUsers();
            }
            return foundUsers;
        }

        public async Task<int> SaveUser(string username, string email)
        {
            User newUser = new(username, email);
            int insertedId = await _pAccess.SaveUser(newUser);
            return insertedId;
        }
    }
}
