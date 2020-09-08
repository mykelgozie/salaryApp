using SalaryApp.SalaryLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryApp.SalaryLib.Interface
{
    public interface IProcessInterface
    {
        // get all employees
        public  List<EmployeDept> GetAllEmployee();

        // get salary range
        public  List<EmployeeClass> GetEmployeeAboveCertainSalary(double salary);

        // add employee
        public void AddEmployee(string firstname, string lastname, string email, int phonenum, DateTime hiredate, double salary, int dept);
        
        // update employee
        public void EmployeeUpdate(string firstname, string lastname, string email, int phonenum, DateTime hiredate, double salary, int dept, int employeid);

        // delete employee
        public void DeleteEmployee(int empid);
        
        // all employee
        public List<EmployeeClass> AllEmployee();
        // get not assign employee
        public List<DepartmentClass> GetNotAssignDept();

        // add department
        public void AddDepartment(string text);

        //  get all department 
        public List<DepartmentClass> Alldepartment();

        // return department by int
        public int GetDepartmentId(string name);

        //  get employee by id
        public  EmployeeClass GetEmployeeWithId(int id);

        // all full employee
        public List<EmployeeClass> GetEmployeeDeptorNoDept();

        // group employyeee
        public IEnumerable<IGrouping<string, EmployeeClass>> GroupByDept();

        // get dept by id
        public DepartmentClass GetDepartmentById(int id);

        // update department 
        public void UpdatDepartment(int id, string name);

        // delete department
        public void DeleteDepartment(int deptid);


     }
}
