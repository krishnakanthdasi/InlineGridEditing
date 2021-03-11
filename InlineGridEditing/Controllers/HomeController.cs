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
        public static List<EmployeeInline> EmpList;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            EmpList = new List<EmployeeInline>();
            EmployeeInline employeesInline;


            for (int i = 1; i <= 6; i++)
            {
                employeesInline = new EmployeeInline()
                {
                    _id = i.ToString(),
                    firstName = "Name" + i.ToString(),
                    lastName = "Last name" + i.ToString(),
                    lastSSN = "Last  SSN" + i.ToString(),
                    department = "Finance",
                    age = 30,
                    salary = "30000",
                    maritalStatus = "Married",
                    permenant = "True"
                };
                EmpList.Add(employeesInline);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGetAttribute]
        public List<EmployeeInline> GetEmployees()
        {
              //var jsonSerializer = new JavaScriptSerializer();
                
              //  context.Response.Write(jsonSerializer.Serialize(collectionEmployee.AsQueryable<EmployeeInline>().ToList<EmployeeInline>()));
           return EmpList;
        }

        [HttpPost]
        public List<EmployeeInline> GetEmployees(EmployeeInline employee)
        {
            //var jsonSerializer = new JavaScriptSerializer();

            //  context.Response.Write(jsonSerializer.Serialize(collectionEmployee.AsQueryable<EmployeeInline>().ToList<EmployeeInline>()));
            return EmpList;
        }
        [HttpPost]
        public List<EmployeeInline> EditEmployee(EmployeeInline employee)
        {
            //  EmployeeInline employee = new EmployeeInline();
            string empid = Request.Form["_id"].ToString();
            if (employee._id == null)
            {
                employee._id = (EmpList.Count + 1).ToString();
                EmpList.Add(employee);
            }
            else
            {

                foreach (EmployeeInline emp in EmpList.Where(w => w._id == employee._id).ToList())
                {
                    emp.firstName = employee.firstName;
                    emp.age = employee.age;
                    emp.department = employee.department;
                    emp.lastName = employee.lastName;
                    emp.maritalStatus = employee.maritalStatus;
                    emp.salary = employee.salary;
                    emp.lastSSN = employee.lastSSN;
                    emp.permenant = employee.permenant;

                }
            }
            return EmpList;
        }
        [HttpPost]
        public List<EmployeeInline> AddEmployee([FromBody] EmployeeInline employee)
        {
            EmpList.Add(employee);
            return EmpList;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
