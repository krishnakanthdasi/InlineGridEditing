using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlineGridEditing.Models
{
    public class Employee
    {
        public string _id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Department { get; set; }
        public int Age { get; set; }
        public string Salary { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }
    }
    public class EmployeeInline
    {

        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string lastSSN { get; set; }
        public string department { get; set; }
        public int age { get; set; }
        public string salary { get; set; }
        public string maritalStatus { get; set; }
        public string permenant { get; set; }

    }
}
