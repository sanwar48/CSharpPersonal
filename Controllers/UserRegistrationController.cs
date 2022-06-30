using AutoMapper;
using Learningproject.DTOs;
using Learningproject.Helpers;
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
        private readonly IMapper _mapper;
        private readonly IUniqueEmailCheck _uniqueEmail;
        private readonly IUniqueUserNameCheck _uniqueUserName;
        private readonly IPasswordValidation _passwordValidation;
        private readonly IPasswordEncryption _IPasswordEncryption;

        public UserRegistrationController(
            ISignupServices signupServices,
            IMapper mapper, 
            IUniqueEmailCheck uniqueEmail, 
            IUniqueUserNameCheck uniqueUserName, 
            IPasswordValidation passwordValidation,
            IPasswordEncryption passwordEncryption

            )
        {
            this._signupServices = signupServices;
            _mapper = mapper;
            _uniqueEmail = uniqueEmail;
            _uniqueUserName = uniqueUserName;
            _passwordValidation = passwordValidation;
            _IPasswordEncryption = passwordEncryption;

        }
        // GET: api/<UserRegistrationController>
        [HttpGet]
        public async Task<List<UserReadDto>> Get()
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
            bool checkUsername = _uniqueUserName.CheckUserName(user.UserName);
            bool checkEmail = _uniqueEmail.CheckUserEmail(user.Email);
            bool checkPasswordValidatios = _passwordValidation.CheckPassword(user.Password);


            if(checkUsername == false && checkEmail == false) return BadRequest("user name and Email already taken");
            if(checkUsername==false && checkEmail==true) return BadRequest("user name already taken");
            if(checkUsername == true && checkEmail == false) return BadRequest("user name already taken");
            if (checkPasswordValidatios == false) return BadRequest("Password is not strong");

            user.Password = _IPasswordEncryption.PasswordEncryptionSHA256(user.Password);


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
