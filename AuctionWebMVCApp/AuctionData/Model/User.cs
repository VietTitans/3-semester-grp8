namespace AuctionData.Model
{
    public class User
    {
        public User() { }

        public User(string username, string email, string profilepicture)
        {
            Username = username;
            Email = email;
            ProfilePicture = profilepicture;
        }

        public User(int id, string username, string email, string profilepicture) : this(username, email, profilepicture)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string ProfilePicture { get; set; }

        public override string? ToString()
        {
            return $"{Username} - {Email}";
        }
    }
}
