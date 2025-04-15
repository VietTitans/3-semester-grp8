using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuctionRestService.Security
{
    public class SecurityHelper
    {
        private readonly IConfiguration _config;

        public SecurityHelper(IConfiguration inConfiguration)
        {
            _config = inConfiguration;
        }

        public SymmetricSecurityKey? GetSecurityKey()
        {
            SymmetricSecurityKey? SIGNING_KEY = null;
            string? SECRET_KEY = _config["SECRET_KEY"];
            if (!string.IsNullOrEmpty(SECRET_KEY))
            {
                SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
            }
            return SIGNING_KEY;
        }

        public bool IsValidUsernameAndPassword(string username, string password)
        {
            var desktopUsername = _config["AllowDesktopApp:Username"];
            var desktopPassword = _config["AllowDesktopApp:Password"];

            var mvcUsername = _config["AllowMvcClient:Username"];
            var mvcPassword = _config["AllowMvcClient:Password"];

            return (username == desktopUsername && password == desktopPassword)
                || (username == mvcUsername && password == mvcPassword);
        }

        public RoleEnum GetRoleEnum(string username)
        {
            var desktopUsername = _config["AllowDesktopApp:Username"];
            var mvcUsername = _config["AllowMvcClient:Username"];

            if (username == desktopUsername)
                return RoleEnum.Admin;
            if (username == mvcUsername)
                return RoleEnum.User;

            return RoleEnum.User; // fallback
        }


    }
}
