using System.Net;
using System.Text;
using Newtonsoft.Json;
using AuctionData.Model;
using Newtonsoft.Json.Linq;

namespace AuctionData.Service
{
    public class UserServiceAccess : ServiceConnection, IUserAccess
    {

        static readonly string authenType = "Bearer";

        public UserServiceAccess() : base("https://localhost:7101/api/users/") { }

        public HttpStatusCode CurrentHttpStatusCode { get; set; }

        // Method to retrieve users – now requires token
        public async Task<List<User>?> GetUsers(string tokenToUse, int id = -1)
        {
            List<User>? usersFromService = null;

            Console.WriteLine("Token being used: " + tokenToUse);


            UseUrl = BaseUrl;
            bool oneUserById = (id > 0);
            if (oneUserById)
            {
                UseUrl += id.ToString();
            }

            // 🔐 Add Authorization header
            string bearerTokenValue = authenType + " " + tokenToUse;
            SetHeaders("Authorization", bearerTokenValue);

            Console.WriteLine("Token being used: " + bearerTokenValue);

            try
            {
                var serviceResponse = await base.CallServiceGet();
                CurrentHttpStatusCode = serviceResponse?.StatusCode ?? HttpStatusCode.BadRequest;

                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    string responseData = await serviceResponse.Content.ReadAsStringAsync();

                    if (oneUserById)
                    {
                        User? foundUser = JsonConvert.DeserializeObject<User>(responseData);
                        if (foundUser != null)
                        {
                            usersFromService = new List<User> { foundUser };
                        }
                    }
                    else
                    {
                        usersFromService = JsonConvert.DeserializeObject<List<User>>(responseData);
                    }
                }
                else if (serviceResponse?.StatusCode == HttpStatusCode.NoContent)
                {
                    usersFromService = new List<User>();
                }
            }
            catch
            {
                usersFromService = null;
            }

            return usersFromService;
        }

        // Save method – also requires token
        public async Task<int> SaveUser(string tokenToUse, User userToSave)
        {
            int insertedUserId = -1;
            UseUrl = BaseUrl;

            // 🔐 Add Authorization header
            string bearerTokenValue = authenType + " " + tokenToUse;
            SetHeaders("Authorization", bearerTokenValue);

            try
            {
                string userJson = JsonConvert.SerializeObject(userToSave);
                var httpContent = new StringContent(userJson, Encoding.UTF8, "application/json");

                var serviceResponse = await base.CallServicePost(httpContent);
                CurrentHttpStatusCode = serviceResponse?.StatusCode ?? HttpStatusCode.BadRequest;

                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    string idString = await serviceResponse.Content.ReadAsStringAsync();
                    bool idNumOk = int.TryParse(idString, out insertedUserId);
                    if (!idNumOk)
                    {
                        insertedUserId = -2;
                    }
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
