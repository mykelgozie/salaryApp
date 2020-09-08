using Microsoft.EntityFrameworkCore;
using SalaryApp.SalaryLib.database;
using SalaryApp.SalaryLib.Interface;
using SalaryApp.SalaryLib.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalaryApp.SalaryLib
{
    // process all datbase query
    public class ProcessEmployeeClass: IProcessInterface
    {


        // get all emlpoye that has department only
        public List<EmployeDept> GetAllEmployee()
        {
           // open connection
            var conn = DatabaseProcessClass.OpenConnection();
            var dept = conn.DepartmentsTable;
            var staff = conn.EmployeesTable;
            // linq query join
            var allEmployee =   staff.Join(dept, s=>s.Department.DepartmentId, d=>d.DepartmentId, (s,d)=> new EmployeDept () { 
            
               Id        = s.EmployeeId,
               FirstName  = s.First_Name,
               LastName   = s.Last_Name,
               Department = d.Department_Name

            }).ToList();

            return allEmployee;
          
        }

        // get employee above certain salary
        public  List<EmployeeClass> GetEmployeeAboveCertainSalary(double salary)
        {
            // open connection
            var conn = DatabaseProcessClass.OpenConnection();
            // select salary
            var employe = conn.EmployeesTable.Where(x => x.Salary > salary).ToList();
            return employe;

        }


        // Add new employee
        public  void AddEmployee(string firstname, string lastname, string email, int phonenum, DateTime hiredate, double salary, int dept)
        {

            //open  datbase connection
            var conn = DatabaseProcessClass.OpenConnection();
            var empDept = conn.DepartmentsTable.Find(dept);
            // employee model properties 
            var staff = new EmployeeClass();
            staff.First_Name = firstname;
            staff.Last_Name = lastname;
            staff.Email = email;
            staff.Phone_Number = phonenum;
            staff.Hire_Date = hiredate;
            staff.Salary = salary;
            staff.Department = empDept;
            conn.EmployeesTable.Add(staff);
            // save changes 
            conn.SaveChanges();

        }

        // update employee
        public void EmployeeUpdate(string firstname, string lastname, string email, int phonenum, DateTime hiredate, double salary, int dept, int employeid)
        {  
            //open database connection
            var conn = DatabaseProcessClass.OpenConnection();
            // find employee with certain id 
            var empDept = conn.DepartmentsTable.Find(dept);
            var employee = conn.EmployeesTable.Find(employeid);
            employee.First_Name = firstname;
            employee.Last_Name = lastname;
            employee.Email = email;
            employee.Phone_Number = phonenum;
            employee.Hire_Date = hiredate;
            employee.Salary = salary;
            employee.Department = empDept;
            conn.EmployeesTable.Update(employee);
            // save changes 
            conn.SaveChanges();


        }

        // Delete employee with certain id 
        public  void DeleteEmployee(int empid)
        {
            // open datbase connection 
            var conn = DatabaseProcessClass.OpenConnection();
            var staff = conn.EmployeesTable.Find(empid);
            conn.EmployeesTable.Remove(staff);
            // save changes 
            conn.SaveChanges();
        }

        //Get all employees with or withiout department
        public List<EmployeeClass> AllEmployee()
        {
            // open connection
            var conn = DatabaseProcessClass.OpenConnection();
            var staff = conn.EmployeesTable.ToList();
            return staff;
        }
        
        // get all department not assigned to any employee
        public  List<DepartmentClass> GetNotAssignDept()
        {
            // open datbase connection
            var conn = DatabaseProcessClass.OpenConnection();
            var staff = conn.EmployeesTable;
            var dept = conn.DepartmentsTable;
            var empIds = staff.Select(emp => emp.Department.DepartmentId);
            var  notAssigndept = dept.Where(dep => empIds.Contains(dep.DepartmentId) == false).ToList();
            return notAssigndept;


        }
        
        // add new department 
        public  void AddDepartment(string text)
        {   
            // open conection
            var conn = DatabaseProcessClass.OpenConnection();
            var department = new DepartmentClass();
            department.Department_Name = text;
            conn.DepartmentsTable.Add(department);
            // save changes 
            conn.SaveChanges();
        }

        // update department 
        public void UpdatDepartment(int id , string name)
        {
            // open connection
            var conn = DatabaseProcessClass.OpenConnection();
            //  find employee with Id
           var deptFound = conn.DepartmentsTable.Find(id);
            deptFound.Department_Name = name;
            conn.DepartmentsTable.Update(deptFound);
            // save changes 
            conn.SaveChanges();


        }
        // delete department by Id 
        public void DeleteDepartment (int deptid)
        {
            // open datbase connection 
            var conn = DatabaseProcessClass.OpenConnection();
            var dept = conn.DepartmentsTable.Find(deptid);
            conn.DepartmentsTable.Remove(dept);
            // save changes 
            conn.SaveChanges();
        }
        //  get departments
        public  List<DepartmentClass> Alldepartment()
        {
            // oppen connection
            var conn = DatabaseProcessClass.OpenConnection();
            var dept =  conn.DepartmentsTable.ToList();
            return dept;


        }

        // search for certain department 
        public int GetDepartmentId(string name)
        {
            var conn = DatabaseProcessClass.OpenConnection();
            var deptId = conn.DepartmentsTable.Where(x=>x.Department_Name == name).FirstOrDefault();
            // return found department
            return deptId.DepartmentId;

        }

        //get dept by id
        public DepartmentClass GetDepartmentById(int id)
        {
            var conn = DatabaseProcessClass.OpenConnection();
            var deptId = conn.DepartmentsTable.Where(x => x.DepartmentId == id).FirstOrDefault();
            // return found department
            return deptId;

        }
        // get partcular employee with Id 
        public  EmployeeClass GetEmployeeWithId(int id)
        {

            var conn = DatabaseProcessClass.OpenConnection();
            var emp = conn.EmployeesTable.Find(id);
            // return employee
            return emp;

        }

        // get all employeee with or without department
        public  List<EmployeeClass> GetEmployeeDeptorNoDept()
        {
            var conn = DatabaseProcessClass.OpenConnection();
            var staff = conn.EmployeesTable.Include(s => s.Department).ToList();
            return staff;
        }

        // get employee by department 
        public IEnumerable<IGrouping< string, EmployeeClass>> GroupByDept()
        {
            var conn = DatabaseProcessClass.OpenConnection();
            var employe = conn.EmployeesTable.Include(s => s.Department).Where(x=>x.Department.Department_Name != null).ToList();
            var ch = employe.GroupBy(x => x.Department.Department_Name);
            return ch;

        }

    }
}
