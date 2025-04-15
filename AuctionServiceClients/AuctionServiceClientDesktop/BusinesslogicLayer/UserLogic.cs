using System.Net;
using AuctionServiceClientDesktop.ModelLayer;
using AuctionServiceClientDesktop.ServiceLayer;
using AuctionServiceClientDesktop.Security;
using AuctionServiceClientDesktop.Servicelayer;

namespace AuctionServiceClientDesktop.Logic
{
    public class UserLogic
    {

        private readonly IUserAccess _uAccess;

        public HttpStatusCode CurrentHttpStatusCode { get; set; }

        public UserLogic()
        {
            _uAccess = new UserServiceAccess();
        }

        // Fetch all users
        public async Task<List<User>?> GetAllUsers()
        {
            List<User>? foundUsers = null;

            // Get token
            TokenState currentState = TokenState.Valid;
            string? tokenValue = await GetToken(currentState);

            if (tokenValue != null)
            {
                foundUsers = await _uAccess.GetUsers(tokenValue);
                if (_uAccess.CurrentHttpStatusCode == HttpStatusCode.Unauthorized)
                {
                    currentState = TokenState.Invalid;
                }
            }
            else
            {
                currentState = TokenState.Invalid;
            }

            if (currentState == TokenState.Invalid)
            {
                tokenValue = await GetToken(currentState);
                if (tokenValue != null)
                {
                    foundUsers = await _uAccess.GetUsers(tokenValue);
                }
            }

            return foundUsers;
        }

        // Save a new user
        public async Task<int> SaveUser(string username, string email)
        {
            int insertedId = -1;
            User newUser = new(username, email);

            // Get token
            TokenState currentState = TokenState.Valid;
            string? tokenValue = await GetToken(currentState);

            if (tokenValue != null)
            {
                insertedId = await _uAccess.SaveUser(tokenValue, newUser);
                if (_uAccess.CurrentHttpStatusCode == HttpStatusCode.Unauthorized)
                {
                    currentState = TokenState.Invalid;
                }
            }
            else
            {
                currentState = TokenState.Invalid;
            }

            if (currentState == TokenState.Invalid)
            {
                tokenValue = await GetToken(currentState);
                if (tokenValue != null)
                {
                    insertedId = await _uAccess.SaveUser(tokenValue, newUser);
                }
                else
                {
                    insertedId = 2; // Could not obtain token after retry
                }
            }

            return insertedId;
        }


        // Relay to token manager
        private async Task<string?> GetToken(TokenState useState)
        {
            TokenManager tokenHelp = new TokenManager();
            string? foundToken = await tokenHelp.GetToken(useState);
            return foundToken;
        }
    }
}
