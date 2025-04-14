namespace AuctionWebMVCApp.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel() { }

        public UserViewModel(string username, string email, string profilepicture)
        {
            Username = username;
            Email = email;
            ProfilePicture = profilepicture;
        }

        public UserViewModel(int id, string username, string email, string profilepicture) : this(username, email, profilepicture)
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
