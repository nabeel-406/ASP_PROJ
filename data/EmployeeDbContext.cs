using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PractiseDemo.Models;

namespace PractiseDemo.data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options){}
        public DbSet<Employee> EmpTable {get; set; }
    }
}