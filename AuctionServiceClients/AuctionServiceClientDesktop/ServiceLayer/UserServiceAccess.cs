using System.Net;
using System.Text;
using Newtonsoft.Json;
using AuctionServiceClientDesktop.ModelLayer;
using AuctionServiceClientDesktop.Servicelayer;

namespace AuctionServiceClientDesktop.ServiceLayer
{
    public class UserServiceAccess : ServiceConnection, IUserAccess
    {

        public UserServiceAccess() : base("https://localhost:7101/api/users/")
        {
        }

        // Method to retrieve users – must handle possible HTTP status codes returned from API
        public async Task<List<User>?> GetUsers(int id = -1)
        {
            List<User>? usersFromService = null;

            UseUrl = BaseUrl;
            bool oneUsersById = (id > 0);
            if (oneUsersById)
            {
                UseUrl += id;
            }
            try
            {
                var serviceResponse = await base.CallServiceGet();
                // if success (200–299)
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    // 200 with data returned
                    if (serviceResponse.StatusCode == HttpStatusCode.OK)
                    {
                        string responseData = await serviceResponse.Content.ReadAsStringAsync();
                        // if asked for 1 user – else asked for all users
                        if (oneUsersById)
                        {
                            User? foundUser = JsonConvert.DeserializeObject<User>(responseData);
                            if (foundUser != null)
                            {
                                usersFromService = new List<User> { foundUser };  // Must return list
                            }
                        }
                        else
                        {
                            usersFromService = JsonConvert.DeserializeObject<List<User>>(responseData);
                        }
                    }
                    else if (serviceResponse.StatusCode == HttpStatusCode.NoContent)
                    {  // 204
                        usersFromService = new List<User>();
                    }
                }
            }
            catch
            {
                usersFromService = null;
            }
            return usersFromService;
        }

        public async Task<int> SaveUser(User userToSave)
        {
            int insertedUserId = -1;

            UseUrl = BaseUrl;
            try
            {
                string userJson = JsonConvert.SerializeObject(userToSave);
                var httpContent = new StringContent(userJson, Encoding.UTF8, "application/json");

                // Call service
                var serviceResponse = await base.CallServicePost(httpContent);

                // If success 200–299
                if (serviceResponse != null && serviceResponse.IsSuccessStatusCode)
                {
                    string idString = await serviceResponse.Content.ReadAsStringAsync();
                    bool idNumOk = int.TryParse(idString, out insertedUserId);
                    if (!idNumOk)
                    {
                        insertedUserId = -2;
                    }
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