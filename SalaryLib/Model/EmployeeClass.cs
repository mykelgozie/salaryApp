using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalaryApp.SalaryLib
{
    // Employee class mapped tp database 
    [Table("Employees")]
    public class EmployeeClass
    {
        // primary key
        [Key]
        public int EmployeeId{ get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public long Phone_Number { get; set; }
        // only date stored
        [DataType(DataType.Date)]
        public  DateTime Hire_Date { get; set; }
        public double Salary { get; set; }

        // automatically creates  foreign key in employee 
        public int? DepartmentId { get; set; }
        public DepartmentClass Department { get; set; }

        

    }
}
