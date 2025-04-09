using AuctionData.Model;
using AuctionData.Service;
using AuctionWebMVCApp.ViewModel;


namespace AuctionWebMVCApp.BusinessLogic
{
    public class UserLogic
    {

        readonly IUserAccess _pAccess;

        public UserLogic()
        {
            _pAccess = new UserServiceAccess();
        }
        public async Task<List<UserViewModel>?> GetAllUsers()
        {
            List<User>? foundUsers = null;
            if (_pAccess != null)
            {
                foundUsers = await _pAccess.GetUsers();
            }
            List<UserViewModel> foundUserViewModels = ModelConversion.UserViewModelConversion.FromUserCollection(foundUsers);
            return foundUserViewModels;
        }
    }
}
