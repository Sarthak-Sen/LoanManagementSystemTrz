using LoanBackendIntegration.Entities;
using LoanBackendIntegration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanBackendIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Route("GetUsers")]
        public IActionResult GetAll()
        {
            try
            {
                return StatusCode(200, _userService.GetAll());
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet, Route("Validate/{email}/{pwd}")]
        public IActionResult Validate(string email, string pwd)
        {
            try
            {

                return StatusCode(200, _userService.Validate(email, pwd));
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost, Route("Create")]
        public IActionResult Create(User user)
        {
            try
            {
                _userService.Register(user);
                return StatusCode(200, user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Authorize(Roles="Customer")]
        [HttpPut, Route("EditUser")]
        public IActionResult Edit(User user)
        {
            try
            {
                _userService.Update(user);
                return StatusCode(200, user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete, Route("DeleteUser/{id}")]
        public IActionResult Delete(string id)
        {
            _userService.Delete(id);
            return StatusCode(200, "User Deleted");
        }
    }
}
