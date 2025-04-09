using AuctionData.Model;
using AuctionWebMVCApp.ViewModel;

namespace AuctionWebMVCApp.ModelConversion
{
    public class UserViewModelConversion
    {
        // Convert from User objects to UserViewModel objects
        public static List<UserViewModel?>? FromUserCollection(List<User> inUsers)
        {
            List<UserViewModel?>? userViewModelList = null;
            if (inUsers != null)
            {
                userViewModelList = new List<UserViewModel?>();
                foreach (User aUser in inUsers)
                {
                    if (aUser != null)
                    {
                        userViewModelList.Add(FromUser(aUser));
                    }
                }
            }
            return userViewModelList;
        }

        // Convert from User object to UserViewModel object
        public static UserViewModel? FromUser(User inUser)
        {
            if (inUser == null) return null;
            return new UserViewModel(inUser.Id, inUser.Username, inUser.Email, inUser.ProfilePicture);
        }

        // Convert from UserViewModel object to User object
        public static User? ToUser(UserViewModel inViewModel)
        {
            if (inViewModel == null) return null;
            return new User(inViewModel.Id, inViewModel.Username, inViewModel.Email, inViewModel.ProfilePicture);
        }
    }
}
