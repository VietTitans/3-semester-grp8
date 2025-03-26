using AuctionData.DatabaseLayer;
using AuctionRestService.DTOs;
using AuctionService.BusinesslogicLayer;
using AuctionData.ModelLayer;

namespace AuctionRestService.BusinesslogicLayer
{

    public class UserDataLogic : IUserData
    {

        private readonly IUserAccess _userAccess;

        public UserDataLogic(IUserAccess inUserAccess)
        {
            _userAccess = inUserAccess;
        }


        public int Add(UserDTO userToAdd)
        {
            int insertedId = 0;
            try
            {
                User? dbUser = ModelConversion.UserDTOConvert.ToUser(userToAdd);
                if (dbUser != null)
                {
                    insertedId = _userAccess.CreateUser(dbUser);
                }
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO? Get(int id)
        {
            UserDTO? foundUserDto;
            try
            {
                User? foundUser = _userAccess.GetUserById(id);
                foundUserDto = ModelConversion.UserDTOConvert.FromUser(foundUser);
            }
            catch
            {
                foundUserDto = null;
            }
            return foundUserDto;
        }


        public List<UserDTO?>? Get()
        {
            List<UserDTO?>? foundDtos;
            try
            {
                List<User>? foundUsers = _userAccess.GetUserAll();
                foundDtos = ModelConversion.UserDTOConvert.FromUserCollection(foundUsers);
            }
            catch
            {
                foundDtos = null;
            }
            return foundDtos;
        }


        public bool Put(UserDTO userToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
