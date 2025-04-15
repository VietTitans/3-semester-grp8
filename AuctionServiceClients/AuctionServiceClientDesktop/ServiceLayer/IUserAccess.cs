using System.Net;
using AuctionServiceClientDesktop.ModelLayer;

namespace AuctionServiceClientDesktop.Servicelayer
{
    public interface IUserAccess
    {
        HttpStatusCode CurrentHttpStatusCode { get; set; }
        Task<List<User>?>? GetUsers(string tokenToUse, int id = -1);
        Task<int> SaveUser(string tokenToUse, User userToSave);

    }
}
