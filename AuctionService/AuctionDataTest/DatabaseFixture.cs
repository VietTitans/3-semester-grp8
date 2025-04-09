using System.Diagnostics;
using AuctionData.DatabaseLayer;
using AuctionData.ModelLayer;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


namespace AuctionDataTest;
public class DatabaseFixture : IDisposable
{

    //Before all
    public DatabaseFixture()
    {
        // Setup logic before all tests are run


        TestUser1 = new User("TestUser1", "TestEmail1", "TestProfilePicture1");
        User testUser2 = new User(GetPcName() + "TestUser2", "TestEmail2", "TestProfilePicture2");
        User testUser3 = new User(GetPcName() + "TestUser3", "TestEmail3", "TestProfilePicture3");
        User testUser4 = new User(GetPcName() + "TestUser4", "TestEmail4", "TestProfilePicture4");
        User testUser5 = new User(GetPcName() + "TestUser5", "TestEmail5", "TestProfilePicture5");

        var connectionString = GetConnectionString();

        UserAccess = new UserDatabaseAccess(connectionString);
        UserAccess.CreateUser(TestUser1);



        Debug.WriteLine("Setting up database...");
    }

    public User TestUser1 { get; private set; }
    public IUserAccess UserAccess { get; set; }
    private string GetConnectionString()
    {
        var inConfig = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory()) // Or specify path to test project if needed
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .Build();
        return inConfig.GetConnectionString("AuctionConnection");
    }

    //After all
    public void Dispose()
    {
        // Cleanup logic after all tests are done
        Debug.WriteLine("Cleaning up database...");
    }

    private string GetPcName()
    {
        return Environment.MachineName;
    }

}
