using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryApp.SalaryLib
{
    // department class mapp to database 
    [Table("Departments")]
    public  class DepartmentClass
    {
        [Key]
        // primary key
        public int DepartmentId{ get; set; }
        // departments
        public string Department_Name { get; set; }

        //public  MyProperty { get; set; 7
    }
}
