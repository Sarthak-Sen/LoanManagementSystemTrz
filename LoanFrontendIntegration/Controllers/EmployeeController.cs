using LoanFrontendIntegration.Models;
using LoanFrontendIntegration.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace LoanFrontendIntegration.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly ILoanService loanService;
        private readonly IUserService userService;

        public EmployeeController()
        {
            loanService = new LoanService();
            userService = new UserService();
        }


        public IActionResult Index()
        {

            string UserId = HttpContext.Session.GetString("UserId");

            if (UserId == null)
            {
                return RedirectToAction("Login", "User");
            }
            //httpcontext.session.clear();
            string UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = UserName;  
            List<Loan> loans = loanService.GetAll();
            return View(loans);
        }


        public IActionResult Confirm(string id)
        {

            string UserId = HttpContext.Session.GetString("UserId");

            if (UserId == null)
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.Decisions = new SelectList(new string[] { "Accepted", "Rejected"});

            Loan loan = loanService.GetAll().SingleOrDefault(l => l.LoanId == id);

            if(loan.Status == "Pending")
            {
                return View(loan);

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Confirm(Loan loan)
        {
            loanService.Update(loan);
            return RedirectToAction("Index");

        }


        public IActionResult Delete(string id)
        {
            string UserId = HttpContext.Session.GetString("UserId");

            if (UserId == null)
            {
                return RedirectToAction("Login", "User");
            }
            loanService.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult Details(string id)
        {
            string UserId = HttpContext.Session.GetString("UserId");

            if (UserId == null)
            {
                return RedirectToAction("Login", "User");
            }
            Loan loan = loanService.GetAll().SingleOrDefault(l => l.LoanId == id);

            return View(loan);
        }

        public IActionResult Customer_Details(string id)
        {
            string UserId = HttpContext.Session.GetString("UserId");

            if (UserId == null)
            {
                return RedirectToAction("Login", "User");
            }
            User user = userService.GetAll().SingleOrDefault(b => b.UserId == id);

            return View(user);
        }
    }
}
