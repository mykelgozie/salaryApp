using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryApp.SalaryLib.database
{
    // datbase context class
    public class DatabaseClass:DbContext
    {
     

        // Employees data 
        public DbSet<EmployeeClass> EmployeesTable { get; set; }

        // Department class
        public DbSet<DepartmentClass> DepartmentsTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // connection string 
            optionsBuilder.UseSqlServer("server=michael;Database=salarydb;Trusted_connection=true");

        }




    }
}
