namespace AuctionData.ModelLayer
{
    public class User
    {
        public User() { }

        public User(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public User(int id, string username, string email) : this(username, email)
        {
            Id = id;
        }

        public int Id { get; init; }
        public string Username { get; set; }
        public string Email { get; set; }

        public bool IsUserEmpty
        {
            get
            {
                return string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email);
            }
        }
    }
}
