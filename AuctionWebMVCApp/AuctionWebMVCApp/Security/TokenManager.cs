using AuctionData.Model;
using AuctionData.Service;

namespace AuctionWebMVCApp.Security
{
    public class TokenManager : ITokenManager
    {

        private readonly IConfiguration _config;

        public TokenManager(IConfiguration config)
        {
            _config = config;
        }

        private ApiAccount GetApiAccountCredentials()
        {
            return new ApiAccount
            {
                Username = _config["JwtSettings:Username"],
                Password = _config["JwtSettings:Password"],
                GrantType = _config["JwtSettings:GrantType"] ?? "User"
            };
        }

        // Relay for calling appropriate method according to TokenState
        public async Task<string?> GetToken(TokenState currentState)
        {
            string? foundToken = null;
            if (currentState == TokenState.Valid)
            {
                foundToken = GetTokenExisting();
            }
            // ✅ Fallback when token is missing or invalid
            if (currentState == TokenState.Invalid || string.IsNullOrWhiteSpace(foundToken))
            {
                foundToken = await GetTokenNew();
            }
            return foundToken;
        }

        // Get existing JWT token
        private string? GetTokenExisting()
        {
            string? foundToken = JWT.CurrentJWT;
            return foundToken;
        }

        // Manage retrieval and persistence of new token value
        private async Task<string?> GetTokenNew()
        {
            string? foundToken;

            // Get AccountData
            ApiAccount accounddata = GetApiAccountCredentials();

            // Access a new Token from service (Web API)
            TokenServiceAccess tokenServiceAccess = new TokenServiceAccess();
            foundToken = await tokenServiceAccess.GetNewToken(accounddata);

            if (foundToken != null)
            {
                JWT.CurrentJWT = foundToken;
            }

            return foundToken;
        }


       
    }
}
