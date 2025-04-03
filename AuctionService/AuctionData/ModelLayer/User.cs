namespace AuctionData.ModelLayer
{
    public class User
    {
        public User() { }

        public User(string username, string email, string profilePicture)
        {
            Username = username;
            Email = email;
            ProfilePicture = profilePicture;
        }

        public User(int id, string username, string email, string profilePicture) : this(username, email, profilePicture)
        {
            Id = id;
        }

        public int Id { get; init; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ?ProfilePicture { get; set; }

        public bool IsUserEmpty
        {
            get
            {
                return string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email);
            }
        }
    }
}
