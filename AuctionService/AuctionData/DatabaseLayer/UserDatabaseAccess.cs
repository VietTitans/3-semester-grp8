using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using AuctionData.ModelLayer;

namespace AuctionData.DatabaseLayer
{
    public class UserDatabaseAccess : IUserAccess
    {

        private readonly string? _connectionString;

        public UserDatabaseAccess(IConfiguration inConfig)
        {
            _connectionString = inConfig.GetConnectionString("AuctionConnection");
        }

        // For test (convenience)
        public UserDatabaseAccess(string inConnectionString)
        {
            _connectionString = inConnectionString;
        }

        // Dapper version
        public int CreateUser(User userToAdd)
        {
            int insertedId = -1;
            string insertString = @"
        INSERT INTO [User](Username, Email)
        OUTPUT INSERTED.ID
        VALUES(@Username, @Email)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                insertedId = con.ExecuteScalar<int>(insertString, userToAdd);
            }
            return insertedId;
        }


        //public int CreateUser(User userToAdd)
        //{
        //    int insertedId = -1;
        //    //
        //    string insertString = "INSERT INTO User(firstName, lastName, mobilePhone) OUTPUT INSERTED.ID VALUES(@FirstNam, @LastNam, @MobilePhon)";
        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    using (SqlCommand CreateCommand = new SqlCommand(insertString, con))
        //    {
        //        // Prepace SQL
        //        SqlParameter fNameParam = new("@FirstNam", userToAdd.FirstName);
        //        CreateCommand.Parameters.Add(fNameParam);
        //        SqlParameter lNameParam = new("@LastNam", userToAdd.LastName);
        //        CreateCommand.Parameters.Add(lNameParam);
        //        SqlParameter mPhoneParam = new("@MobilePhon", userToAdd.MobilePhone);
        //        CreateCommand.Parameters.Add(mPhoneParam);
        //        //
        //        con.Open();
        //        // Execute save and read generated key (ID)
        //        insertedId = (int)CreateCommand.ExecuteScalar();
        //    }
        //    return insertedId;
        //}


        public bool DeleteUserById(int id)
        {
            throw new NotImplementedException();
        }

        /* Three possible returns:
         * A User object (normal case)
         * An empty User object (no match on id)
         * Null - Some error occurred
        */
        //public User GetUserById(int findId)
        //{
        //    User foundUser;
        //    //
        //    string queryString = "SELECT id, firstName, lastName, mobilePhone FROM User where id = @Id";
        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    using (SqlCommand readCommand = new SqlCommand(queryString, con))
        //    {
        //        // Prepace SQL
        //        SqlParameter idParam = new SqlParameter("@Id", findId);
        //        readCommand.Parameters.Add(idParam);
        //        //
        //        con.Open();
        //        // Execute read
        //        SqlDataReader userReader = readCommand.ExecuteReader();
        //        foundUser = new User();
        //        while (userReader.Read())
        //        {
        //            foundUser = GetUserFromReader(userReader);
        //        }
        //    }
        //    return foundUser;
        //}

        public User GetUserById(int findId)
        {
            const string queryString = @"
        SELECT Id, Username, Email
        FROM [User]
        WHERE Id = @Id";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                return con.QueryFirstOrDefault<User>(queryString, new { Id = findId });
            }
        }


        public bool UpdateUser(User userToUpdate)
        {
            throw new NotImplementedException();
        }

        /* Three possible returns:
         * A List<User> with content (normal case)
        * A List<User> with no content (no rows found in table)
        * Null - Some error occurred
        */
        //public List<User> GetUserAll()
        //{
        //    List<User> foundUsers;
        //    User readUser;
        //    //
        //    string queryString = "SELECT id, firstName, lastName, mobilePhone FROM User";
        //    using (SqlConnection con = new SqlConnection(_connectionString))
        //    using (SqlCommand readCommand = new SqlCommand(queryString, con))
        //    {
        //        con.Open();
        //        // Execute read
        //        SqlDataReader userReader = readCommand.ExecuteReader();
        //        // Collect data
        //        foundUsers = new List<User>();
        //        while (userReader.Read())
        //        {
        //            readUser = GetUserFromReader(userReader);
        //            foundUsers.Add(readUser);
        //        }
        //    }
        //    return foundUsers;
        //}

        public List<User> GetUserAll()
        {
            const string queryString = @"
        SELECT Id, Username, Email
        FROM [User]";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                return con.Query<User>(queryString).ToList();
            }
        }


        //private User GetUserFromReader(SqlDataReader userReader)
        //{
        //    User foundUser;
        //    int tempId;
        //    bool differsFromNull;     // Test for null value in mobilePhone
        //    string? tempMobilePhone;
        //    string tempFirstName, tempLastName;
        //    // Fetch values
        //    tempId = userReader.GetInt32(userReader.GetOrdinal("id"));
        //    tempFirstName = userReader.GetString(userReader.GetOrdinal("firstName"));
        //    tempLastName = userReader.GetString(userReader.GetOrdinal("lastName"));
        //    differsFromNull = !userReader.IsDBNull(userReader.GetOrdinal("mobilePhone"));
        //    tempMobilePhone = differsFromNull ? userReader.GetString(userReader.GetOrdinal("mobilePhone")) : null;
        //    // Create object
        //    foundUser = new User(tempId, tempFirstName, tempLastName, tempMobilePhone);
        //    return foundUser;
        //}



    }
}
