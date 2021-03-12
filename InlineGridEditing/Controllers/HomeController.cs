using InlineGridEditing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InlineGridEditing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
             
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetEmployees()
        {

            //var jsonSerializer = new JavaScriptSerializer();

            //  context.Response.Write(jsonSerializer.Serialize(collectionEmployee.AsQueryable<EmployeeInline>().ToList<EmployeeInline>()));
            return new JsonResult(Data.empList);
        }

        
        [HttpPost]
        public IActionResult EditEmployee(EmployeeInline employee)
        {
            //  EmployeeInline employee = new EmployeeInline();
            bool status = false;
            try
            {

                EmployeeInline employeeInline = Data.empList.FirstOrDefault(c => c.id == employee.id);
                if (employeeInline == null)
                {
                    employee.id = Data.empList.Count + 1;
                    Data.empList.Add(employee);
                }
                else
                {
                    employeeInline.firstName = employee.firstName;
                    employeeInline.age = employee.age;
                    employeeInline.department = employee.department;
                    employeeInline.lastName = employee.lastName;
                    employeeInline.maritalStatus = employee.maritalStatus;
                    employeeInline.salary = employee.salary;
                    employeeInline.lastSSN = employee.lastSSN;
                    employeeInline.permenant = employee.permenant;
                }

               
                status = true;
            }
            catch (Exception)
            {

                 
            }
            return Json(new { Status = status, EmpId = employee.id });

        }
        
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            bool status = false;

            try
            {
                EmployeeInline employeeInline = Data.empList.FirstOrDefault(c => c.id == id);
                if (employeeInline != null)
                {
                    Data.empList.Remove(employeeInline);
                    status = true;
                }
            }
            catch
            { }

            return Json(status);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
