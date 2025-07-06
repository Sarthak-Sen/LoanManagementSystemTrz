using LoanFrontendIntegration.Models;
using LoanFrontendIntegration.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanFrontendIntegration.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ILoanService loanService;
        private readonly IUserService userService;

        public CustomerController()
        {
            loanService = new LoanService();
            userService = new UserService();

        }


        public IActionResult Index()
        {

            string UserName = HttpContext.Session.GetString("UserName");
            string UserId = HttpContext.Session.GetString("UserId");

            if(UserId == null)
            {
                return RedirectToAction("Login", "User");
            }

            ViewBag.UserName = UserName;
            ViewBag.UserId = UserId;
            //List<Loan> loans = loanService.GetAll();
            
            return View();
        }

        public IActionResult Mydetails(string id)
        {
            string UserId = HttpContext.Session.GetString("UserId");
            string UserName = HttpContext.Session.GetString("UserName");


            if (UserId == null)
            {
                return RedirectToAction("Login", "User");
            }
            User user = userService.GetAll().SingleOrDefault(u => u.UserId == id);
            ViewBag.UserId = id;
            ViewBag.UserName = UserName;
            return View(user);
        }

        public IActionResult Myloans(string id)
        {
            string UserName = HttpContext.Session.GetString("UserName");
            ViewBag.UserName = UserName;
            //List<Loan> loans = loanService.SpecificUsers(id);
            List<Loan> loans = loanService.SpecificUsers(id);

            return View(loans);
        }

        //[HttpGet]
        //public IActionResult Myedit(string id)
        //{
        //    User user = userService.GetAll().SingleOrDefault(u => u.UserId == id);
        //    ViewBag.UserId = id;
        //    return View(user);
        //}

        //[HttpPost]
        //public IActionResult Myedit(User user)
        //{
        //    userService.Update(user);
        //    return RedirectToAction("Mydetails");
        //}




        [HttpGet]
        public IActionResult Create(string type)
        {

            string UserId = HttpContext.Session.GetString("UserId");

            if (UserId == null)
            {
                return RedirectToAction("Login", "User");
            }
            string UserName = HttpContext.Session.GetString("UserName");
            //string UserId = HttpContext.Session.GetString("UserId");
            int? CreditScore = HttpContext.Session.GetInt32("CreditScore");
            ViewBag.UserId = UserId;
            ViewBag.UserName = UserName;
            ViewBag.CreditScore = CreditScore;

            ViewBag.LoanType = type;


            //ViewBag.LoanTypeItems = new SelectList(new string[] { "Personal", "Home", "Credit", "Gold", "Business", "Medical", "Student" });
            //ViewBag.StatusItems = new SelectList(new string[] { "Accepted", "Rejected" });

            return View();
        }

        [HttpPost]
        public IActionResult Create(Loan loan)
        {
            loan.AmountLeft = loan.LoanPrincipal;
            loan.LoanId = "L" + new Random().Next();
            loanService.Add(loan);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Payoff(string id)
        {

            string UserId = HttpContext.Session.GetString("UserId");

            if (UserId == null)
            {
                return RedirectToAction("Login", "User");
            }
            Loan loan = loanService.GetAll().SingleOrDefault(l => l.LoanId == id);
            ViewBag.Banks = new SelectList(new string[] { "SBI", "HDFC", "ICICI" });

            if (loan.Status == "Accepted")
            {
                string UserName = HttpContext.Session.GetString("UserName");
                //string UserId = HttpContext.Session.GetString("UserId");
                int? CreditScore = HttpContext.Session.GetInt32("CreditScore");
                ViewBag.UserId = UserId;
                ViewBag.UserName = UserName;
                ViewBag.CreditScore = CreditScore;
                return View(loan);
            }
            else
            {
                return RedirectToAction("Index");

            }

        }

        [HttpPost]
        public IActionResult Payoff(Loan loan)
        {
            loan.AmountLeft = loan.AmountLeft - loan.Repay;
            if(loan.AmountLeft < 0)
            {
                loan.AmountLeft = 0;
            }
            //Console.WriteLine("Hi2");
            loanService.Update(loan);
            return RedirectToAction("Index", "Customer");
        }
    }
}
