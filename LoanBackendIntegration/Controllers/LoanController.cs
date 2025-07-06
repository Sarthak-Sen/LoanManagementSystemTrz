using LoanBackendIntegration.Entities;
using LoanBackendIntegration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanBackendIntegration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet, Route("GetAllLoans")]
        public IActionResult GetAll()
        {
            try
            {
                return StatusCode(200, _loanService.GetAll());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet, Route("GetById/{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                return StatusCode(200, _loanService.GetById(id));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost, Route("Apply")]
        public IActionResult Add(Loan loan)
        {
            try
            {
                _loanService.Add(loan);
                return StatusCode(200, loan);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete, Route("DeleteLoan/{id}")]
        public IActionResult Delete(string id)
        {
            _loanService.Delete(id);
            return StatusCode(200, "Loan Deleted");
        }

        [HttpPut, Route("EditLoan")]
        public IActionResult Edit(Loan loan)
        {
            try
            {
                //loan.LoanPrincipal = loan.LoanPrincipal - loan.Repay;
                _loanService.Update(loan);
                return StatusCode(200, loan);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet, Route("GetLoanDetails/{id}")]
        public IActionResult GetItem(string id)
        {
            try
            {
                return StatusCode(200, _loanService.GetItem(id));
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
