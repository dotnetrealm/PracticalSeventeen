using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PracticalSeventeen.Data.Interfaces;
using PracticalSeventeen.Data.ViewModels;
using System.Security.Claims;

namespace PracticalSeventeen.Controllers
{
    public class AccountController : Controller
    {
        readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public async Task<IActionResult> LoginAsync()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Student");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(Credential credential)
        {
            if (ModelState.IsValid)
            {
                var data = await _accountRepository.GetUserByEmailPasswordAsync(credential.Email, credential.Password);
                if (data == null)
                {
                    ModelState.AddModelError("", "Invalid Email/Password.");
                    ViewBag.Error = "Invalid Email/Password.";
                    return View();
                }

                List<Claim> claims = new List<Claim>() {
                                        new Claim(ClaimTypes.Email, data.User.Email),
                                        new Claim(ClaimTypes.Name, data.User.Firstname + " " + data.User.LastName),
                                        new Claim(ClaimTypes.Role, data.Role),
                                        new Claim("UserId", data.User.Id.ToString())
                                    };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "AccountCookie");
                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

                AuthenticationProperties properties = new AuthenticationProperties
                {
                    IsPersistent = credential.RememberMe,
                };

                await HttpContext.SignInAsync("AccountCookie", principal, properties);

                return RedirectToAction("Index", "Student");
            }
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PageNotFound()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("AccountCookie");
            return RedirectToAction("Index", "Student");
        }
    }
}
