using AuctionData.ModelLayer;
using AuctionRestService.DTOs;

namespace AuctionRestService.ModelConversion
{
    public class UserDTOConvert
    {
        // Convert from User objects to UserDTO objects
        public static List<UserDTO?>? FromUserCollection(List<User> inUsers)
        {
            List<UserDTO?>? aUserReadDtoList = null;
            if (inUsers != null)
            {
                aUserReadDtoList = new List<UserDTO?>();
                foreach (User aUser in inUsers)
                {
                    if (aUser != null)
                    {
                        aUserReadDtoList.Add(FromUser(aUser));
                    }
                }
            }
            return aUserReadDtoList;
        }

        // Convert from User object to UserDTO object
        public static UserDTO? FromUser(User inUser)
        {
            if (inUser == null) return null;
            return new UserDTO(inUser.Username, inUser.Email);
        }

        // Convert from UserDTO object to User object
        public static User? ToUser(UserDTO inDto)
        {
            if (inDto == null) return null;
            return new User(inDto.Username, inDto.Email);
        }
    }
}
