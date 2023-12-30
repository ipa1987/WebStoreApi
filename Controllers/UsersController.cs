using Microsoft.AspNetCore.Mvc;
using WebStoreApi.Models;

namespace WebStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<UserDto> listUsers = new List<UserDto>()
        {
            new UserDto()
        {
                FirstName = "Bill",
                LastName = "Gates",
                Email = "bill@microsoft.com",
                Phone = "+123456789",
                Address = "New York, USA"
        }
    };

        [HttpGet]
        public IActionResult GetUsers()
        {
            if (listUsers.Count > 0)
            {
                return Ok(listUsers);
            }
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            if (id >= 0 && id < listUsers.Count)
            {
                return Ok(listUsers[id]);
            }
            return NotFound();
        }

        [HttpGet("{name}")]
        public IActionResult GetUser(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            return Ok(name);
        }

        [HttpPost]
        public IActionResult AddUser(UserDto user)
        {
            // check email is not authorised

            if (user.Email.Equals("user@example.com"))
            {
                ModelState.AddModelError("Email", "This email is not authorised");
                return BadRequest(ModelState);
            }


            listUsers.Add(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserDto user)
        {
            if (user.Email.Equals("user@example.com"))
            {
                ModelState.AddModelError("Email", "This email is not authorised");
                return BadRequest(ModelState);
            }


            if (id >= 0 && id < listUsers.Count)
            {
                listUsers[id] = user;
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id >= 0 && id < listUsers.Count)
            {
                listUsers.RemoveAt(id);
            }
            return NoContent();
        }
    }
}