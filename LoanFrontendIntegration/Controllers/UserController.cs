using LoanFrontendIntegration.Models;
using LoanFrontendIntegration.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanFrontendIntegration.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController()
        {
            userService = new UserService();
        }

        public IActionResult Index()
        {
            try
            {
                /* if (HttpContext.Session.GetString("UserId") != null)
                 {*/
                List<User> users = userService.GetAll();
                return View(users);
                /*}
                else
                {
                    return RedirectToAction("Login");
                }*/


            }
            catch (Exception)
            {

                return View("Error");
            }
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                User user = userService.Validate(login);
                if (user == null)
                {
                    ViewBag.ErrorMsg = "Invalid Credentials";
                    return View();
                }
                else
                {
                    //Set Value in Session
                    HttpContext.Session.SetString("UserId", user.UserId); //Storing UserId in Session
                    HttpContext.Session.SetString("UserName", user.UserName); //Storing UserId in Session
                    HttpContext.Session.SetInt32("CreditScore", user.CreditScore); //Storing UserId in Session
                    HttpContext.Session.SetString("Role", user.Role); //Storing UserId in Session

                    string role = user.Role;
                    /*ViewBag.UserName = user.UserName;
                    ViewBag.UserId = user.UserId;
                    ViewBag.CreditScore = user.CreditScore;*/

                    if (role == "Employee")
                    {
                        return RedirectToAction("Index", "Employee");
                    }
                    else if (role == "Customer")
                    {
                        return RedirectToAction("Index", "Customer");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
            else
            {
                return View();
            }
        }


/*        public IActionResult CustomerDash()
        {
            string userId = HttpContext.Session.GetString("UserId");
            string Uname = HttpContext.Session.GetString("Uname");

            ViewBag.Uname = Uname;


            return View();
        }
*/

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Items = new SelectList(new string[] { "Customer", "Employee"});
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
          /*  if (ModelState.IsValid) //Add Check for email
            {*/
                user.UserId = "U" + new Random().Next();
                userService.Register(user);
                return RedirectToAction("Login");

            /*}
            else
            {
                return View();
            }*/
        }


        public IActionResult Edit(string id)
        {
            User user = userService.GetAll().SingleOrDefault(b => b.UserId == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            userService.Update(user);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(string id)
        {
            userService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        

    }
}
