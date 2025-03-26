using Microsoft.AspNetCore.Mvc;
using AuctionRestService.BusinesslogicLayer;
using AuctionRestService.DTOs;
using AuctionService.BusinesslogicLayer;

namespace AuctionRestService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserData _businessLogicCtrl;

        // Constructor with Dependency Injection
        public UsersController(IUserData inBusinessLogicCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
        }

        // URL: api/users
        [HttpGet]
        public ActionResult<List<UserDTO>> Get()
        {
            ActionResult<List<UserDTO>> foundReturn;
            // retrieve data - converted to DTO
            List<UserDTO?>? foundUsers = _businessLogicCtrl.Get();
            // evaluate
            if (foundUsers != null)
            {
                if (foundUsers.Count > 0)
                {
                    foundReturn = Ok(foundUsers);             // Statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);    // Ok, but no content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        // Internal server error
            }
            // send response back to client
            return foundReturn;
        }


        // URL: api/users/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            ActionResult<UserDTO> foundReturn;
            // retrieve data - converted to DTO
            UserDTO? foundUser = _businessLogicCtrl.Get(id);
            // evaluate
            if (foundUser != null)
            {
                foundReturn = Ok(foundUser);             // Statuscode 200
            }
            else
            {
                foundReturn = new StatusCodeResult(500);    // Internal server error
            }
            // send response back to client
            return foundReturn;
        }

        // URL: api/users
        [HttpPost]
        public ActionResult<int> PostNewUser(UserDTO inUserDto)
        {
            ActionResult<int> foundReturn;
            int insertedId = -1;
            if (inUserDto != null)
            {
                insertedId = _businessLogicCtrl.Add(inUserDto);
            }
            // Evaluate
            if (insertedId > 0)
            {
                foundReturn = Ok(insertedId);
            }
            else if (insertedId == 0)
            {
                foundReturn = BadRequest();     // missing input
            }
            else
            {
                foundReturn = new StatusCodeResult(500);    // Internal server error
            }
            return foundReturn;
        }


    }
}
