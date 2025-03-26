using AuctionRestService.DTOs;

namespace AuctionService.BusinesslogicLayer
{

    public interface IUserData
    {

        UserDTO? Get(int id);
        List<UserDTO?>? Get();
        int Add(UserDTO userToAdd);
        bool Put(UserDTO userToUpdate);
        bool Delete(int id);

    }
}
