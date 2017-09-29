using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AskToniApi.Models;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AskToniApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public Task<IEnumerable<User>> Get(int pageOffset = 0, int pageLimit = 0)
        {
            return GetUsers(pageOffset, pageLimit);
        }

        private async Task<IEnumerable<User>> GetUsers(int pageOffset, int pageLimit)
        {
            if (pageLimit > 0)
            {
                throw new NotImplementedException();
            }
            else
            {
                return await _userRepository.GetAllUsers();
            }
        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody]User value)
        {
            _userRepository.AddUser(new User() 
                                    { FirstName = value.FirstName,
                                    LastName = value.LastName});
        } 
    }
}