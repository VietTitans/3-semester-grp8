namespace AuctionRestService.DTOs
{
    public class UserDTO
    {
        public UserDTO() { }

        public UserDTO(int id, string username, string email, string profilepicture)
        {
            Id = id;
            Username = username;
            Email = email;
            ProfilePicture = profilepicture;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; } 
        public string? ProfilePicture { get; set; }
    }
}
