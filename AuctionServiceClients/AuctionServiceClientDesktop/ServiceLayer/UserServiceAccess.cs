using System.Net;
using System.Text;
using Newtonsoft.Json;
using AuctionServiceClientDesktop.ModelLayer;
using AuctionServiceClientDesktop.Servicelayer;

namespace AuctionServiceClientDesktop.ServiceLayer
{
    public class UserServiceAccess : ServiceConnection, IUserAccess
    {

        static readonly string authenType = "Bearer";

        public UserServiceAccess() : base("https://localhost:7101/api/users/")
        {
        }

        public HttpStatusCode CurrentHttpStatusCode { get; set; }

        // Method to retrieve User(s)
        public async Task<List<User>?> GetUsers(string tokenToUse, int id = -1)
        {
            List<User>? usersFromService = null;

            UseUrl = BaseUrl;
            bool hasValidId = (id > 0);
            if (hasValidId)
            {
                UseUrl += id.ToString();
            }

            // Must add Bearer token to request header
            string bearerTokenValue = authenType + " " + tokenToUse;
            SetHeaders("Authorization", bearerTokenValue);

            try
            {
                var serviceResponse = await CallServiceGet();
                CurrentHttpStatusCode = serviceResponse != null ? serviceResponse.StatusCode : HttpStatusCode.BadRequest;

                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    var content = await serviceResponse.Content.ReadAsStringAsync();
                    if (hasValidId)
                    {
                        User? foundUser = JsonConvert.DeserializeObject<User>(content);
                        if (foundUser != null)
                        {
                            usersFromService = new List<User>() { foundUser };
                        }
                    }
                    else
                    {
                        usersFromService = JsonConvert.DeserializeObject<List<User>>(content);
                    }
                }
                else if (serviceResponse != null && serviceResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    usersFromService = new List<User>();
                }
                else
                {
                    usersFromService = null;
                }
            }
            catch
            {
                usersFromService = null;
            }
            return usersFromService;
        }

        // Method to save User
        public async Task<int> SaveUser(string tokenToUse, User userToSave)
        {
            int insertedUserId = -1;
            UseUrl = BaseUrl;

            string bearerTokenValue = authenType + " " + tokenToUse;
            SetHeaders("Authorization", bearerTokenValue);

            try
            {
                var json = JsonConvert.SerializeObject(userToSave);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var serviceResponse = await CallServicePost(content);
                CurrentHttpStatusCode = serviceResponse != null ? serviceResponse.StatusCode : HttpStatusCode.BadRequest;

                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    string resIdString = await serviceResponse.Content.ReadAsStringAsync();
                    bool idIsOk = int.TryParse(resIdString, out insertedUserId);
                    if (!idIsOk) { insertedUserId = -4; }
                }
                else
                {
                    insertedUserId = -2;
                }
            }
            catch
            {
                insertedUserId = -3;
            }

            return insertedUserId;
        }
    }
}
