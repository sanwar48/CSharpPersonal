using Learningproject.DTOs;
using Learningproject.Models;

namespace Learningproject.Services
{
    public interface ISignupServices
    {
        public Task<List<UserReadDto>> GetAsync();
        public  Task<User> GetAsync(string id);
        public Task  CreateAsync(User user);
        public void Update(string id, User user);
        public void Delete(string id);
    }
}
