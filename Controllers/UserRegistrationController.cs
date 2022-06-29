using Learningproject.Models;
using Learningproject.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Learningproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly ISignupServices _signupServices;

        public UserRegistrationController(ISignupServices signupServices)
        {
            this._signupServices = signupServices;
        }
        // GET: api/<UserRegistrationController>
        [HttpGet]
        public async Task<List<User>> Get()
        {
          return await _signupServices.GetAsync();
        }

        // GET api/<UserRegistrationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            return await _signupServices.GetAsync(id);
        }

        // POST api/<UserRegistrationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            await _signupServices.CreateAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }

        // PUT api/<UserRegistrationController>/5
        [HttpPut("{id}")]
        public  ActionResult Put(string id, [FromBody] User newuser)
        {
            _signupServices.Update(id, newuser);
            return NoContent();
        }

        // DELETE api/<UserRegistrationController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _signupServices.Delete(id);
            return NoContent();
        }
    }
}
