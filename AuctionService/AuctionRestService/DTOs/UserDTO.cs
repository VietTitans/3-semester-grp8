namespace AuctionRestService.DTOs
{
    public class UserDTO
    {
        public UserDTO() { }

        public UserDTO(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public string Username { get; set; }
        public string Email { get; set; } 

    }
}
