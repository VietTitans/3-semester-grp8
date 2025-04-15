using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionData.Model;

namespace AuctionData.Service;

public class TokenServiceAccess : ServiceConnection, ITokenServiceAccess
{

    // Insert your own port no
    public TokenServiceAccess() : base("https://localhost:7101")
    {
    }

    // Fetch service from service
    public async Task<string?> GetNewToken(ApiAccount accountToUse)
    {
        string? retrievedToken = null;

        UseUrl = BaseUrl.TrimEnd('/') + "/token";
        var uriToken = new Uri(UseUrl);

        HttpContent appAdminLogin = new FormUrlEncodedContent(new[]
        {
        new KeyValuePair<string, string>("grant_type", accountToUse.GrantType),
        new KeyValuePair<string, string>("username", accountToUse.Username),
        new KeyValuePair<string, string>("password", accountToUse.Password)
    });

        HttpRequestMessage request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = uriToken,
            Content = appAdminLogin
        };

        try
        {
            var response = await CallServicePost(request);
            response?.EnsureSuccessStatusCode();

            if (response != null)
            {
                retrievedToken = await response.Content.ReadAsStringAsync();
                retrievedToken = retrievedToken?.Trim('"'); // Ensure valid JWT format
            }

            Console.WriteLine("Retrieved token: " + retrievedToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Token request failed: " + ex.Message);
            retrievedToken = null;
        }

        return retrievedToken;
    }

}
