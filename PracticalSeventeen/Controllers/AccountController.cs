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

        /// <summary>
        /// Return login view
        /// </summary>
        /// <param name="returnurl">redirect url after successful login</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login(string? returnurl)
        {
            ViewBag.ReturnUrl = returnurl;
            if (User.Identity!.IsAuthenticated)
                return RedirectToAction("Index", "Student");
            return View();
        }

        /// <summary>
        /// Redirect to dashboard/returnurl on valid user credentials
        /// </summary>
        /// <param name="returnurl">redirect url after successful login</param>
        /// <param name="credential">Usercreadential object</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(string? returnurl, Credential credential)
        {
            ViewBag.ReturnUrl = returnurl;
            if (!ModelState.IsValid) return View(credential);

            var data = await _accountRepository.GetUserByEmailPasswordAsync(credential.Email, credential.Password);
            if (data == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid Email/Password.");
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

            if (returnurl is not null && Url.IsLocalUrl(returnurl)) return Redirect(returnurl);

            return RedirectToAction("Index", "Student");
        }

        /// <summary>
        /// Redirect to access denied error page
        /// </summary>
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        /// <summary>
        /// Redirect to access page not found error page
        /// </summary>
        [HttpGet]
        public IActionResult PageNotFound()
        {
            return View();
        }

        /// <summary>
        /// Clear user identity and return to login page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("AccountCookie");
            return RedirectToAction("Login", "Account");
        }
    }
}
