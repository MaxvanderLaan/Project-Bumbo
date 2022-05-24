using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web;
using Bumbo.Domain.Services.Credentials;
using Bumbo.Web.Models.Credentials;

namespace Bumbo.Web.Controllers
{
    [AllowAnonymous]
    public class CredentialsController : Controller
    {
        private readonly ICredentials _serviceCredentials;

        public CredentialsController(ICredentials serviceCredentials)
        {
            _serviceCredentials = serviceCredentials;
        }

        // GET: CredentialsController/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: CredentialsController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password,returnUrl")] LoginModel credentials)
        {
            if (ModelState.IsValid)
            {
                bool result = await _serviceCredentials.Login(credentials.Email, credentials.Password);
                if (result)
                {
                    return LocalRedirect(credentials.returnUrl);
                }
                else
                {
                    ModelState.AddModelError("Password", "Inloggen is niet gelukt. Probeer het nog een keer");
                }
            }
            return View(credentials);
        }

        // GET: CredentialsController/WachtwoordVergeten
        [HttpGet]
        public ActionResult WachtwoordVergeten()
        {
            return View();
        }

        // POST: CredentialsController/WachtwoordVergeten
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WachtwoordVergeten([Bind("Email","Url")] WachtwoordVergetenModel data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // get password reset token of the user by email
                    Task<string> token = _serviceCredentials.PasswordForgot(data.Email);
                    if (token != null)
                    {
                        // Build the password reset link
                        string passwordResetLink = "https://bumbo-group-k.azurewebsites.net/Credentials/VeranderWachtwoord?email=" + data.Email +
                                                   "&token=" + HttpUtility.UrlEncode(token.Result);
                        bool result = _serviceCredentials.sendEmailPasswordForgot(data.Email, passwordResetLink);
                        if (result)
                        {
                            return RedirectToAction(nameof(WachtwoordEmail));
                        }
                        ModelState.AddModelError("Email", "Email kon niet worden verstuurd");
                    }
                }
                return View(data);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Email", ex.Message);
                return View(data);
            }
        }

        // GET: CredentialsController/VeranderWachtwoord
        [HttpGet]
        public ActionResult VeranderWachtwoord()
        {
            return View();
        }

        // POST: CredentialsController/WachtwoordVergeten
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VeranderWachtwoord([Bind("Email,Password,Password2,token")] VeranderWachtwoordModel data)
        {
            if (ModelState.IsValid)
            {
                Task<bool> result = _serviceCredentials.setNewPassword(data.Email, data.Password);
                if (result.Result)
                {
                    return RedirectToAction(nameof(Login));
                }
                ModelState.AddModelError("Password", "Er kon geen nieuwe wachtwoord worden gezet.");
                return View(data);
            }
            ModelState.AddModelError("Email", "Model is niet valid.");
            return View(data);
        }

        // GET: CredentialsController/WachtwoordEmail
        [HttpGet]
        public ActionResult WachtwoordEmail()
        {
            return View();
        }

        // GET: CredentialsController/EmailVerifieren
        [HttpGet]
        public ActionResult EmailVerifieren([Bind("email,token")] EmailVerifierenModel data)
        {
            _serviceCredentials.verifieerEmail(data.email, data.token);
            return View();
        }

        // GET: CredentialsController/ToLoginPage
        [HttpPost]
        public ActionResult ToLoginPage()
        {
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public ActionResult logout()
        {
            _serviceCredentials.Logout();
            return RedirectToAction(nameof(Login));
        }
    }
}
