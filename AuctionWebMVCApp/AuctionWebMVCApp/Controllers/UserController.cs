using AuctionWebMVCApp.BusinessLogic;
using AuctionWebMVCApp.Security;
using AuctionWebMVCApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionWebMVCApp.Controllers
{
    
    public class UserController : Controller
    {
        private readonly ITokenManager _tokenManager;
        private readonly UserLogic _userLogic;

        public UserController(UserLogic userLogic, ITokenManager tokenManager)
        {
            _userLogic = userLogic;
            _tokenManager = tokenManager;
        }

        [Authorize]
        public async Task<IActionResult> All()
        {
            string? token = await _tokenManager.GetToken(TokenState.Valid);
            List<UserViewModel> users = await _userLogic.GetAllUsers(token);
            return View(users);
        }
    }
}
