using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiseDemo.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Departmnet { get; set; }
        public long Number { get; set; }
        public long Salary { get; set; }

    }
}