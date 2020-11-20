using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
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
        private readonly IUserRoleRepository _userRoleRepository;
        public AccountController(IUserRepository userRepository, ISurveyorRepository surveyorRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _surveyorRepository = surveyorRepository;
            _userRoleRepository = userRoleRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel { ReturnURL= returnUrl};
            return View(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetUserUsingCredentials(model.UserName, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Username/Password incorect");
                    return View(model);
                }
                var surveyor = _surveyorRepository.GetSurveyor(user.SurveyorID);
                var userRole = _userRoleRepository.GetUserRole(user.UserRoleID);
                model.ReturnURL = string.IsNullOrEmpty(model.ReturnURL) ? returnUrl : model.ReturnURL;
                if (surveyor != null && userRole !=null)
                {
                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, surveyor.Name),
                    new Claim(ClaimTypes.Role, userRole.Name),
                    new Claim("UserRoleID", userRole.ID.ToString()),
                    new Claim("SurveyorID",surveyor.ID.ToString()),
                    new Claim("UserID",user.ID.ToString())
                    };
                    var userIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync("CookieAuthentication", principal, new AuthenticationProperties { ExpiresUtc = DateTime.UtcNow.AddMinutes(60) });
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "SurveyFile");
                    }
                    else
                    {
                        return Redirect(returnUrl);
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