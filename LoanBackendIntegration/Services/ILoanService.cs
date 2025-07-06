using LoanBackendIntegration.Entities;

namespace LoanBackendIntegration.Services
{
    public interface ILoanService
    {
        void Add(Loan loan);
        void Delete(string id);
        void Update(Loan loan);
        List<Loan> GetAll();
        List<Loan> GetById(string id);
        Loan GetItem(string id);
    }
}
