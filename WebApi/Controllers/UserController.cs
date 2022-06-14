using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<object> AddUser(UserModal userModal)
        {
            string username = Regex.Replace(userModal.FirstName, @"\s", "") + Regex.Replace(userModal.LastName, @"\s", "");
            var user = new User()
            {
                FirstName = userModal.FirstName,
                LastName = userModal.LastName,
                Email = userModal.Email,
                UserName = username
            };
            try
            {
                var result = await _userManager.CreateAsync(user, userModal.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
