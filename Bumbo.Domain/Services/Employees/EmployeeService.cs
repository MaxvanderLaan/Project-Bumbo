using System.Linq;
using Bumbo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace Bumbo.Domain.Services.Employees
{
    public class EmployeeService : IEmployee
    {
        private readonly BumboContext ctx;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EmployeeService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, BumboContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            ctx = context;
        }

        public List<Employee> getEmloyeesWithDepartmens()
        {
            return ctx.Employees.Include(d => d.Departments).ThenInclude(d => d.Department).ToList();
        }

        public void setEmployee(Employee model)
        {
            ctx.Employees.Add(model);
            ctx.SaveChanges();
        }

        public string findUserName(string firstName, string middleName, string lastName)
        {
            string FullName = "";

            if (middleName == null)
            {
                FullName = UppercaseFirst(firstName) + UppercaseFirst(lastName);
            }
            else
            {
                FullName = UppercaseFirst(firstName) + UppercaseFirst(middleName) + UppercaseFirst(lastName);
            }

            string username = FullName.Replace(" ", "");
            int number = 0;
            while (true)
            {
                number++;
                Task<IdentityUser> user = _userManager.FindByNameAsync(username);
                if (user.Result == null)
                {
                    break;
                }
                else
                {
                    username = FullName + number;
                }
            }
            return username;
        }

        public bool CheckEmailExistAlready(string email)
        {
            Task<IdentityUser> user = _userManager.FindByEmailAsync(email);
            return user.Result != null;
        }

        public bool CheckBsnExistAlready(int Bsn)
        {
            if (ctx.Employees.Where(e => e.Bsn == Bsn).ToList().Count != 0)
            {
                return true;
            }
            return false;
        }

        private static string UppercaseFirst(string name)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(name[0]) + name.Substring(1);
        }

        public string createUser(string url, string Firstname, string UserName, string Email, string PhoneNumber, string BirthMonth)
        {
            IdentityUser user = new IdentityUser { UserName = UserName, Email = Email, PhoneNumber = PhoneNumber };
            string password = Firstname + BirthMonth + GetRandomPassword(8) + "!";
            IdentityResult result = _userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                emailVerificationEmail(url, UserName, Email, password);
                _userManager.AddToRoleAsync(user, "Medewerker").Wait();
                return user.Id;
            }

            return null;
        }

        private static string GetRandomPassword(int length)
        {
            const string chars = "0123456789!@#$%^&*";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }

        private async void emailVerificationEmail(string url, string UserName, string Email, string password)
        {
            // Find the user by email
            IdentityUser user = await _userManager.FindByEmailAsync(Email);
            // If the user is found AND Email is confirmed
            if (user != null)
            {
                // Generate the reset password token
                string tokenEmail = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if (tokenEmail != null)
                {
                    string emailVerificationLink = "https://bumbo-group-k.azurewebsites.net/Credentials/EmailVerifieren?email=" + Email + "&token=" + HttpUtility.UrlEncode(tokenEmail);
                    string loginLink = "https://bumbo-group-k.azurewebsites.net/Credentials/Login";
                    sendEmailVerification(UserName, Email, password, emailVerificationLink, loginLink);
                }
            }
        }

        private void sendEmailVerification(string UserName, string Email, string password, string emailVerificationLink, string loginLink)
        {
            MailAddress fromAddress = new MailAddress("no-reply@bumbo.site");
            MailAddress toAddress = new MailAddress(Email);

            MailMessage message = new MailMessage(fromAddress.Address, toAddress.Address);
            string htmlFile = "<!doctype html><html lang='nl-NL'> <head> <meta content='text/html; charset=utf-8' http-equiv='Content-Type'/> <title>Bumbo email verifiëren</title> <meta name='description' content='Bumbo email verifiëren'> <style type='text/css'> a:hover{text-decoration: underline !important;}</style> </head> <body marginheight='0' topmargin='0' marginwidth='0' style='margin: 0px; background-color: #f2f3f8;' leftmargin='0'> <table cellspacing='0' border='0' cellpadding='0' width='100%' bgcolor='#f2f3f8' style='@import url(https://fonts.googleapis.com/css?family=Rubik:300,400,500,700|Open+Sans:300,400,600,700); font-family: 'Open Sans', sans-serif;'> <tr> <td> <table style='background-color: #f2f3f8; max-width:670px; margin:0 auto;' width='100%' border='0' align='center' cellpadding='0' cellspacing='0'> <tr> <td style='height:80px;'>&nbsp;</td></tr><tr> <td style='text-align:center;'> <a href='https://bumbo-group-k.azurewebsites.net' title='logo' target='_blank'> <img width='200' src='https://bumbo-group-k.azurewebsites.net/assets/images/Bumbo-Logo.png' title='logo' alt='logo'> </a> </td></tr><tr> <td style='height:20px;'>&nbsp;</td></tr><tr> <td> <table width='95%' border='0' align='center' cellpadding='0' cellspacing='0' style='max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);'> <tr> <td style='height:40px;'>&nbsp;</td></tr><tr> <td style='padding:0 35px;'> <h1 style='color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family:'Rubik',sans-serif;'>Je bumbo account is aangemaakt of bijgewerkt</h1> <span style='display:inline-block; vertical-align:middle; margin:29px 0 26px; border-bottom:1px solid #cecece; width:100px;'></span> <p style='color:#455056; font-size:15px;line-height:24px; margin:0;'> Met dit account kan je <a href='LoginURL' style='text-decoration:none; color:black;'>inloggen</a> op het inlog systeem van bumbo. Maar je moet wel eerst even je email verifiëren.</p><br><p>Gebruikersnaam: PlaceUserName<br>Email: PlaceEmail<br>Wachtwoord: PlaceWachtwoord</p><a href='VerfierenURL' style='background:#f5c105;text-decoration:none !important; font-weight:500; margin-top:35px; color:#fff;text-transform:uppercase; font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;'>Email Verifiëren</a> </td></tr><tr> <td style='height:40px;'>&nbsp;</td></tr></table> </td><tr> <td style='height:20px;'>&nbsp;</td></tr><tr> <td style='text-align:center;'> <p style='font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0 0 0;'>&copy; <strong>Bumbo</strong></p></td></tr><tr> <td style='height:80px;'>&nbsp;</td></tr></table> </td></tr></table> </body></html>";
            string mailbody = htmlFile.Replace("VerfierenURL", emailVerificationLink);
            mailbody = mailbody.Replace("LoginURL", loginLink);
            mailbody = mailbody.Replace("PlaceUserName", UserName);
            mailbody = mailbody.Replace("PlaceEmail", Email);
            mailbody = mailbody.Replace("PlaceWachtwoord", password);
            message.Subject = "Bumbo Email Verifiëren";
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Employee getEmployee(int id)
        {
            return ctx.Employees.Include(b => b.Branch).Where(e => e.EmployeeId == id).Single();
        }

        public Employee getEmployeeWithBSN(int bsn)
        {
            return ctx.Employees.Where(e => e.Bsn == bsn).Single();
        }

        public void addEmployeeDepartments(int employeeId, List<int> departments)
        {
            foreach (int id in departments)
            {
                EmployeeHasDepartments ehp = new EmployeeHasDepartments();
                ehp.EmployeeId = employeeId;
                ehp.DepartmentId = id;
                ctx.EmployeeHasDepartments.Add(ehp);
            }
            ctx.SaveChanges();
        }

        public List<Branch> getBranch()
        {
            return ctx.Branches.ToList();
        }

        public List<Function> getFunctions()
        {
            return ctx.Functions.ToList();
        }

        public List<Department> getDepartments()
        {
            return ctx.Departments.ToList();
        }

        public List<Contract> getContractsByEmployeeId(int EmployeeId)
        {
            return ctx.Contracts.Where(c => c.EmployeeId == EmployeeId).Include(c => c.Function).ToList();
        }

        public List<Department> getDepartmentsByEmployeeId(int EmployeeId)
        {
            //Returns List of Departments Employee is registered for
            List<EmployeeHasDepartments> EmployeeHasDepartmentList = ctx.EmployeeHasDepartments.Where(e => e.EmployeeId == EmployeeId).ToList();
            List<Department> DepartmentsList = ctx.Departments.ToList();
            List<Department> EmployeeList = new List<Department>();
            foreach (EmployeeHasDepartments department in EmployeeHasDepartmentList)
            {
                EmployeeList.Add(DepartmentsList.Where(dep => dep.Id == department.DepartmentId).Single());
            }
            return EmployeeList;
        }

        public string getEmailByUserId(string userId)
        {
            Task<IdentityUser> user = _userManager.FindByIdAsync(userId);
            return user.Result.Email;
        }

        public string getPhoneNumberByUserId(string userId)
        {
            Task<IdentityUser> user = _userManager.FindByIdAsync(userId);
            return user.Result.PhoneNumber;
        }

        public async Task<string> getRollByUserId(string userId)
        {
            IdentityUser User = await _userManager.FindByIdAsync(userId);

            if (User != null)
            {
                IList<string> deleteList = _userManager.GetRolesAsync(User).Result;
                return deleteList[0];
            }

            return null;
        }

        public void editEmployee(Employee employee)
        {
            ctx.Employees.Attach(employee);
            ctx.Employees.Update(employee);

            ctx.SaveChanges();
        }

        public async Task<bool> editEmail(string url, string userId, string email)
        {
            IdentityUser user = await _userManager.FindByIdAsync(userId);
            if (user.Email != email)
            {
                string tokenEmail = await _userManager.GenerateChangeEmailTokenAsync(user, email);
                await _userManager.ChangeEmailAsync(user, email, tokenEmail);
                user.EmailConfirmed = false;
                await _userManager.UpdateAsync(user);
                emailVerificationEmail(url, user.UserName, email, "**********");
            }
            return true;
        }

        public async Task<bool> editPhoneNumber(string userId, string phoneNumber)
        {
            IdentityUser user = await _userManager.FindByIdAsync(userId);
            if (user.PhoneNumber != phoneNumber)
            {
                string tokenPhoneNumber = await _userManager.GenerateChangePhoneNumberTokenAsync(user, phoneNumber);
                await _userManager.ChangePhoneNumberAsync(user, phoneNumber, tokenPhoneNumber);
                user.PhoneNumberConfirmed = false;
                await _userManager.UpdateAsync(user);
            }
            return true;
        }

        public void editEmployeeDepartments(Employee employee, List<int> departments)
        {
            //Remove old
            ctx.EmployeeHasDepartments
                .Where(ehp => !departments.Contains(ehp.DepartmentId) && ehp.EmployeeId == employee.EmployeeId).ToList()
                .ForEach(ehp => ctx.EmployeeHasDepartments.Remove(ehp));
            //Add new
            IEnumerable<int> departmentsToAdd = departments.Except(ctx.EmployeeHasDepartments
                .Where(ehp => departments.Contains(ehp.DepartmentId) && ehp.EmployeeId == employee.EmployeeId)
                .Select(ehp => ehp.DepartmentId).ToList());
            foreach (int id in departmentsToAdd)
            {
                EmployeeHasDepartments ehp = new EmployeeHasDepartments();
                ehp.EmployeeId = employee.EmployeeId;
                ehp.DepartmentId = id;
                ctx.EmployeeHasDepartments.Add(ehp);
            }
            ctx.SaveChanges();
        }

        public void createContract(Contract model)
        {
            ctx.Contracts.Add(model);
            ctx.SaveChanges();
        }

        public void endContract(int contractId)
        {
            Contract contract = ctx.Contracts.Where(c => c.ContractId == contractId).Single();
            contract.EndDate = DateTime.Now;
            ctx.Contracts.Update(contract);
            ctx.SaveChanges();
        }

        public int getEmployeeIdFromContractId(int contractId)
        {
            Contract contract = ctx.Contracts.Where(c => c.ContractId == contractId).Single();
            return contract.EmployeeId;
        }

        public List<ProfileColleague> getColleagues(ClaimsPrincipal currentUser)
        {
            List<ProfileColleague> Colleagues = new List<ProfileColleague>();
            Task<IdentityUser> currentuser = _userManager.FindByNameAsync(currentUser.Identity.Name);
            Employee currentEmployee = ctx.Employees.Where(e => e.userId == currentuser.Result.Id).FirstOrDefault();
            List<Employee> employees = new List<Employee>();
            employees = ctx.Employees.Where(e => e.BranchId == currentEmployee.BranchId && e.userId != currentuser.Result.Id).Include(e => e.Departments).ThenInclude(b => b.Department).ToList();
            for (int i = 0; i < employees.Count; i++)
            {
                Task<IdentityUser> user = _userManager.FindByIdAsync(employees[i].userId);
                ProfileColleague colleague = new ProfileColleague();
                colleague.FirstName = employees[i].FirstName;
                colleague.MiddleName = employees[i].MiddleName;
                colleague.LastName = employees[i].LastName;
                colleague.Departments = employees[i].Departments;
                colleague.PhoneNumber = user.Result.PhoneNumber;
                Colleagues.Add(colleague);
            }
            return Colleagues;
        }

        public Employee getEmployeeById(ClaimsPrincipal currentUser)
        {
            Task<IdentityUser> user = _userManager.FindByNameAsync(currentUser.Identity.Name);
            return ctx.Employees.Include(b => b.Branch).Where(e => e.userId == user.Result.Id).FirstOrDefault();
        }

        public List<IdentityRole> getRolls()
        {
            return _roleManager.Roles.ToList();
        }

        //edit employee roll
        public async Task editEmployeeRoll(string NewRole, string email)
        {
            IdentityUser User = await _userManager.FindByEmailAsync(email);

            if (User != null)
            {
                foreach (string roleName in _userManager.GetRolesAsync(User).Result)
                {
                    Task result = _userManager.RemoveFromRoleAsync(User, roleName);
                    await result;
                }
                Task result2 = _userManager.AddToRoleAsync(User, NewRole);
                await result2;
            }
        }

        //checks for edit employee roll
        public IList<string> getRollFromUserId(string userId)
        {
            IdentityUser User = ctx.Users.Where(U => U.Id == userId).FirstOrDefault();
            return _userManager.GetRolesAsync(User).Result;
        }

        public bool checkEditSelf(Employee model, string EditorId)
        {
            if (model.userId == EditorId)
            {
                return false;
            }
            return true;
        }

        public bool CheckRollChange(string NewRole, string userId)
        {
            foreach (string roll in getRollFromUserId(userId))
            {
                if (roll != NewRole)
                {
                    return true;
                }
            }

            return false;
        }

        public bool checkIfBsnAlreadyExist(int bsn)
        {
            if (ctx.Employees.Where(e => e.Bsn == bsn).ToList().Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}