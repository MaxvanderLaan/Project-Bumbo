using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Bumbo.Domain.Services.Credentials
{
    public class CredentialsService : ICredentials
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BumboContext ctx;

        public CredentialsService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, BumboContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            ctx = context;
        }

        public async Task<bool> Login(string Email, string Password)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(Email);
            if(user == null)
            {
                //No user found
                return false;
            }
            else
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //Login
                    return true;
                }
                else
                {
                    //Invalid login attempt
                    return false;
                }
            }
        }

        public async Task<string> PasswordForgot(string Email)
        {
            // Find the user by email
            IdentityUser user = await _userManager.FindByEmailAsync(Email);
            // If the user is found
            if (user != null)
            {
                // Generate the reset password token
                string result = await _userManager.GeneratePasswordResetTokenAsync(user);
                return result;
            }
            return null;
        }

        public bool sendEmailPasswordForgot(string Email, string resetUrl)
        {
            MailAddress fromAddress = new MailAddress("no-reply@bumbo.site");
            MailAddress toAddress = new MailAddress(Email);

            MailMessage message = new MailMessage(fromAddress.Address, toAddress.Address);
            string htmlFile = "<!doctype html><html lang='nl-NL'><head> <meta content='text/html; charset=utf-8' http-equiv='Content-Type'/> <title>Bumbo password reset</title> <meta name='description' content='Bumbo password reset'> <style type='text/css'> a:hover{text-decoration: underline !important;}</style></head><body marginheight='0' topmargin='0' marginwidth='0' style='margin: 0px; background-color: #f2f3f8;' leftmargin='0'> <table cellspacing='0' border='0' cellpadding='0' width='100%' bgcolor='#f2f3f8' style='@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;'> <tr> <td> <table style='background-color: #f2f3f8; max-width:670px; margin:0 auto;' width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> <tr> <td style='height:80px;'>&nbsp;</td></tr><tr> <td style='text-align:center;'> <a href='https://bumbo-group-k.azurewebsites.net' title='logo' target='_blank'> <img width='200' src='https://bumbo-group-k.azurewebsites.net/assets/images/Bumbo-Logo.png' title='logo' alt='logo'> </a> </td></tr><tr> <td style='height:20px;'>&nbsp;</td></tr><tr> <td> <table width='95%' border='0' align='center' cellpadding='0' cellspacing='0' style='max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);'> <tr> <td style='height:40px;'>&nbsp;</td></tr><tr> <td style='padding:0 35px;'> <h1 style='color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;'>Jij hebt een verzoek ingediend om uw wachtwoord opnieuw in te stellen</h1> <span style='display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;'></span> <p style='color:#455056; font-size:15px;line-height:24px; margin:0;'> We kunnen je niet zomaar je oude wachtwoord toesturen. Een unieke link om je wachtwoord te resetten is voor u aangemaakt. Om uw wachtwoord opnieuw in te stellen, klikt u op de volgende link en volg de instructies. </p><a href='Replace' style='background:#f5c105;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;'>Reset Wachtwoord</a> </td></tr><tr> <td style='height:40px;'>&nbsp;</td></tr></table> </td><tr> <td style='height:20px;'>&nbsp;</td></tr><tr> <td style='text-align:center;'> <p style='font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0 0 0;'>&copy; <strong>Bumbo</strong></p></td></tr><tr> <td style='height:80px;'>&nbsp;</td></tr></table> </td></tr></table> </body></html>";
            string mailbody = htmlFile.Replace("Replace", resetUrl);
            message.Subject = "Bumbo password reset";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient(); //Vimexx smtp    
            client.Host = "mail.bumbo.site";
            client.Port = 587;
            client.Timeout = 10000;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("no-reply@bumbo.site", "UX5eZEki"); ;
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> setNewPassword(string Email, string Password)
        {
            IdentityUser User = await _userManager.FindByEmailAsync(Email);
            if (User != null)
            {
                string newPasswordHash = _userManager.PasswordHasher.HashPassword(User, Password);

                User.PasswordHash = newPasswordHash;
                IdentityResult result = await _userManager.UpdateAsync(User);

                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> verifieerEmail(string Email, string token)
        {
            IdentityUser User = await _userManager.FindByEmailAsync(Email);
            if (User != null)
            {
                IdentityResult result = await _userManager.ConfirmEmailAsync(User, token);

                if (result.Succeeded)
                {
                    User.EmailConfirmed = true;
                    await _userManager.UpdateAsync(User);
                    return true;
                }
            }
            return false;
        }

        public void Logout()
        {
            _signInManager.SignOutAsync();
        }
    }
}
