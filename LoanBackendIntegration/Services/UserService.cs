using LoanBackendIntegration.Entities;

namespace LoanBackendIntegration.Services
{
    public class UserService : IUserService
    {

        private readonly MyContext _context;

        public UserService(MyContext context)
        {
            _context = context;
        }

        public void Delete(string userId) //Delete User Details using ID
        {
            try
            {
                User user = _context.Users.Find(userId);
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void Register(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Update(User user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public User Validate(string email, string pwd)
        {
            try
            {
                User user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == pwd);
                return user;
            }
            catch
            {
                throw;
            }
        }
    }
}
