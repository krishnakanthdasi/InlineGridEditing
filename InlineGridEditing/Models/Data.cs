using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlineGridEditing.Models
{
    public static class Data
    {
        public static ICollection<EmployeeInline> empList { get; private set; }

        static Data()
        {

            List<EmployeeInline> EmpList = new List<EmployeeInline>();
            EmployeeInline employeesInline;


            for (int i = 1; i <= 6; i++)
            {
                employeesInline = new EmployeeInline()
                {
                    id = i,
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

            empList = EmpList;

        }

    }
}
