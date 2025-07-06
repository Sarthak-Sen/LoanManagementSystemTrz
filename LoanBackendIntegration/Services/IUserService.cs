using LoanBackendIntegration.Entities;

namespace LoanBackendIntegration.Services
{
    public interface IUserService
    {
        void Register(User user);
        List<User> GetAll();
        User Validate(string email, string pwd);
        void Update(User user);
        void Delete(string userId);
    }
}
