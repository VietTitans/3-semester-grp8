using AuctionData.Model;
using AuctionData.Service;
using AuctionWebMVCApp.ViewModel;


namespace AuctionWebMVCApp.BusinessLogic
{
    public class UserLogic
    {
        private readonly IUserAccess _uAccess;

        public UserLogic()
        {
            _uAccess = new UserServiceAccess();
        }

        public async Task<List<UserViewModel>?> GetAllUsers(string token)
        {
            List<User>? foundUsers = null;

            if (_uAccess != null)
            {
                foundUsers = await _uAccess.GetUsers(token);
            }

            List<UserViewModel> foundUserViewModels =
                ModelConversion.UserViewModelConversion.FromUserCollection(foundUsers);

            return foundUserViewModels;
        }
    }

}
