using System.Diagnostics;

namespace AuctionData.DatabaseLayer;
public class DatabaseFixture
{
    //Before all
    public DatabaseFixture()
    {
        Debug.WriteLine("Setting up database...");
    }

    //After all
    public void Dispose()
    {
        // Cleanup logic after all tests are done
        Debug.WriteLine("Cleaning up database...");
    }

}
