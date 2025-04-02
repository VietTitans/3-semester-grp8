using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using AuctionData.DatabaseLayer;
using AuctionData.ModelLayer;
using Xunit;
using Xunit.Abstractions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuctionDataTest
{

    public class TestUserDataAccess
    {

        private readonly ITestOutputHelper _extraOutput;
        private readonly IUserAccess _userAccess;
        private readonly string _connectionString = "Data Source=localhost;Initial Catalog=AuctionDB;Persist Security Info=True;User ID=sa;Password=@12tf56so;Encrypt=False";
        public TestUserDataAccess(ITestOutputHelper tOutput)
        {
            _extraOutput = tOutput;
            _userAccess = new UserDatabaseAccess(_connectionString);
        }

        [Fact]
        public void TestGetUserAll()
        {
            // Arrange

            // Act
            List<User> readUsers = _userAccess.GetUserAll();
            bool usersWereRead = (readUsers.Count > 0);
            // Print additional output
            _extraOutput.WriteLine("Number of users: " + readUsers.Count);

            // Assert
            Assert.True(usersWereRead);
        }

        [Fact]
        public void TestUserIsNoLongerInDatabase_When_UserIsDeletedByID()
        {
            // Arrange
            User userToDelete = new User();
            userToDelete.Username = "TestUser";
            userToDelete.Email = "TestEmail";
            int idOfUserToDelete = _userAccess.CreateUser(userToDelete);
            

            // Act
            bool userIsDeleted = _userAccess.DeleteUserById(idOfUserToDelete);
            User userFoundAfterDeletion = _userAccess.GetUserById(idOfUserToDelete);

            // Assert
            Assert.True(userIsDeleted);
            Assert.Null(userFoundAfterDeletion);

        }

    }
}