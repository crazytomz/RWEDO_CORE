using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RWEDO.MSQLRepository.Contracts;
using RWEDO.ViewModels;

namespace RWEDO.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISurveyorRepository _surveyorRepository;
        public AccountController(IUserRepository userRepository, ISurveyorRepository surveyorRepository)
        {
            _userRepository = userRepository;
            _surveyorRepository = surveyorRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetUserUsingCredentials(model.UserName, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Username/Password incorect");
                    return View(model);
                }

                var result = _surveyorRepository.GetSurveyor(user.SurveyorID);

                if (result != null)
                {
                    if (result != null)
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("index", "home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }
        [AllowAnonymous]
        public ActionResult Forbidden()
        {
            return View();
        }
    }
}