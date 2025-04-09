using AuctionWebMVCApp.BusinessLogic;
using AuctionWebMVCApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionWebMVCApp.Controllers
{
    
    public class UserController : Controller
    {
        [Authorize]
        public async Task<IActionResult> All()
        {
            UserLogic userLogic = new UserLogic();
            List<UserViewModel> users = await userLogic.GetAllUsers();
            return View(users);
        }
    }
}
