using Bumbo.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bumbo.Domain.Services.Employees
{
    public interface IEmployee
    {
        //Index Page
       List<Employee> getEmloyeesWithDepartmens();
        //Create page
       void setEmployee(Employee model);
       string findUserName(string firstName, string middleName, string lastName);
       bool CheckEmailExistAlready(string Email);
       string createUser(string url, string Firstname, string UserName, string Email, string PhoneNumber, string BirthMonth);
       Employee getEmployee(int employeeId);
       Employee getEmployeeWithBSN(int employeeBsn);
       void addEmployeeDepartments(int employeeId, List<int> departments);

        //Edit Page
       List<Branch> getBranch();
       List<Function> getFunctions();
       List<Department> getDepartments();
       List<Contract> getContractsByEmployeeId(int employeeId);
       List<Department> getDepartmentsByEmployeeId(int employeeId);
       string getEmailByUserId(string userId);
       string getPhoneNumberByUserId(string userId);
       Task<string> getRollByUserId(string userId);
       void editEmployee(Employee employee);
       Task<bool> editEmail(string url, string userId, string email);
       Task<bool> editPhoneNumber(string userId, string phoneNumber);
       void editEmployeeDepartments(Employee employee, List<int> departments);

        //Contract Page
       void createContract(Contract model);
       void endContract(int contractId);
       int getEmployeeIdFromContractId(int contractId);
        bool checkIfBsnAlreadyExist(int bsn);

        //Profile Page
       List<ProfileColleague> getColleagues(ClaimsPrincipal user);
       Employee getEmployeeById(ClaimsPrincipal user);

       bool CheckBsnExistAlready(int Bsn);

        //rolls 
       List<IdentityRole> getRolls();
       bool checkEditSelf(Employee model, string EditorId);
       bool CheckRollChange(string NewRole, string userId);
       IList<string> getRollFromUserId(string userId);
       Task editEmployeeRoll(string NewRole, string email);
    }
}