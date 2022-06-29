using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vertiv.Interfaces;
using Vertiv.Models;

namespace Vertiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInputController : ControllerBase
    {
        private readonly IUserInputService _userInputService;
        public UserInputController(IUserInputService userInputService)
        {
            _userInputService = userInputService;
        }

        [HttpGet]
        public IActionResult GetPasswords()
        {
             var userInput = _userInputService.GetAvailablePassword();
            if (userInput != null)
                return Ok(userInput);
            return NotFound("There is no valid password at this time");

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody]int id)
        {
            if (_userInputService.PasswordStillValid())
                return BadRequest("Password still valid!");
            else if (_userInputService.OneTimePasswordExpired(id))
                return BadRequest("Password expired for this user");
            else
            {
               var userInput = _userInputService.CreateUserPassword(id);
                return Ok(userInput);
            }
        }
    }
}
