using System.Diagnostics;
using AuctionData.DatabaseLayer;
using AuctionData.ModelLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


namespace AuctionDataTest;
public class DatabaseFixture
{
    private IConfiguration inConfig;

    //Before all
    public DatabaseFixture()
    {
        // Setup logic before all tests are run
        User testUser1 = new User(GetPcName() + "TestUser1", "TestEmail1");
        User testUser2 = new User(GetPcName() + "TestUser2", "TestEmail2");
        User testUser3 = new User(GetPcName() + "TestUser3", "TestEmail3");
        User testUser4 = new User(GetPcName() + "TestUser4", "TestEmail4");
        User testUser5 = new User(GetPcName() + "TestUser5", "TestEmail5");

        var connectionString = GetConnectionString();

        UserDatabaseAccess userAccess = new UserDatabaseAccess(connectionString);
        userAccess.CreateUser(testUser1);



        Debug.WriteLine("Setting up database...");
    }

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
