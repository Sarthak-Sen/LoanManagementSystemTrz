using LoanBackendIntegration.Entities;

namespace LoanBackendIntegration.Services
{
    public class LoanService : ILoanService
    {

        private readonly MyContext _context;

        public LoanService(MyContext context)
        {
            _context = context;
        }

        public void Add(Loan loan)
        {
            try
            {
                _context.Loans.Add(loan);
                _context.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public void Delete(string id)
        {
            try
            {
                Loan loan = _context.Loans.Find(id);
                _context.Loans.Remove(loan);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Loan> GetAll()
        {
            try
            {
                return _context.Loans.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Loan> GetById(string id)
        {
            try
            {
                List<Loan> specific = new List<Loan>();
                List<Loan> loop = _context.Loans.ToList();
                foreach (Loan loan in loop)
                {
                    if(loan.UserId == id)
                    {
                        specific.Add(loan);
                    }
                }
                return specific;
                //User user = _context.Users.Find(id);

                //List<Loan> specific = new List<Loan>();
                //Loan loan = _context.Loans.SingleOrDefault(l => l.UserId == id);
                //specific.Add(loan);
                //return specific;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Loan GetItem(string id)
        {
            try
            {
                Loan loan = _context.Loans.Find(id);
                return loan;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(Loan loan)
        {
            try
            {
                _context.Loans.Update(loan);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
