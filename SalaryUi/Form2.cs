using SalaryApp.SalaryLib;
using SalaryApp.SalaryLib.database;
using SalaryApp.SalaryLib.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalaryApp.SalaryUi
{
    public partial class Form2 : Form
    {
        public IProcessInterface Process { get; set; }
        public Form2(IProcessInterface query)
        {
            InitializeComponent();
            Process = query;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            loadpage();
            

        }
        // delete employe button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {    
                 // get selected id
                 var id =   dataGridView1.SelectedCells[0].Value.ToString();
                    // delete 
                 Process.DeleteEmployee(Convert.ToInt32(id));
                 MessageBox.Show(" Employee Deleted");
                  dataGridView1.Rows.Clear();
                 loadpage();

            }
            catch (Exception)
            {
                // error message 
                MessageBox.Show("Invalid Operation");
            }
        }
        // loadepage method oo laod all employee
        private void loadpage()
        {
            button13.Enabled = false;
            button12.Enabled = false;
            // create column in datgridview
            dataGridView1.ColumnCount = 3;
            // auto size column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //column properties
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "First Name";
            dataGridView1.Columns[2].Name = "Last Name";
       
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            var allEmploye = Process.GetEmployeeDeptorNoDept();
            foreach (var item in allEmploye)
            {

                dataGridView1.Rows.Add(item.EmployeeId, item.First_Name, item.Last_Name);
            }

        }

        // department page
        private void button4_Click(object sender, EventArgs e)
        {
            // new department page
            DepartmentForm department = new DepartmentForm(Process);
            department.ShowDialog();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button13.Enabled = false;
            button12.Enabled = false;
            button3.Enabled = true;
            button7.Enabled = true;

            try
            {

            dataGridView1.Rows.Clear();
            var salary = textBox1.Text;
            var staffSalary =  Process.GetEmployeeAboveCertainSalary(Convert.ToDouble(salary));

            // create column in datgridview
            dataGridView1.ColumnCount = 4;
            // auto size column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //column properties
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "First Name";
            dataGridView1.Columns[2].Name = "Last Name";
            dataGridView1.Columns[3].Name = "Salary";
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            foreach (var item in staffSalary)
            {
                dataGridView1.Rows.Add(item.EmployeeId, item.First_Name, item.Last_Name, item.Salary);
            }


            }
            catch (Exception)
            {

                MessageBox.Show("Please Enter a valid Salary");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

            button3.Enabled = false;
            button7.Enabled = false;
            button13.Enabled = true;
            button12.Enabled = true;
           
            dataGridView1.Rows.Clear();
            // create column in datgridview
            dataGridView1.ColumnCount = 2;
            // auto size column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //column properties
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "Departments";
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            var allDepts = Process.Alldepartment();

                    foreach (var item in allDepts)
                    {

                        dataGridView1.Rows.Add(item.DepartmentId, item.Department_Name);
                    }

            }
            catch (Exception)
            {

                MessageBox.Show("Invalid Operattion");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button7.Enabled = false;
            button12.Enabled = true;
            button13.Enabled = true;
            dataGridView1.Rows.Clear();
            // create column in datgridview
            dataGridView1.ColumnCount = 2;
            // auto size column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //column properties
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "Departments";
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            var allDepts = Process.GetNotAssignDept();
            foreach (var item in allDepts)
            {
                dataGridView1.Rows.Add(item.DepartmentId, item.Department_Name);

            }

        }
        // add employee page
        private void button8_Click(object sender, EventArgs e)
        {
            AddEmployee page = new AddEmployee(Process);
             page.ShowDialog();
        }

        // edit new page 
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

          
            var id = dataGridView1.SelectedCells[0].Value.ToString();
            EditEmployee page = new EditEmployee(int.Parse(id) , Process);
            page.ShowDialog();

            }
            catch (Exception)
            {

                MessageBox.Show("Invalid Operation");
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            // create column in datgridview
            dataGridView1.ColumnCount = 4;
            // auto size column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //column properties
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "First Name";
            dataGridView1.Columns[2].Name = "Last Name";
            dataGridView1.Columns[3].Name = "Department";
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            var allDepts = Process.GetAllEmployee();
            foreach (var item in allDepts)
            {
                dataGridView1.Rows.Add(item.Id, item.FirstName, item.LastName, item.Department);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            GroupForm page = new GroupForm(Process);
            page.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                dataGridView1.Rows.Clear();
                var staffSalary = Process.GetEmployeeAboveCertainSalary(150000);

                // create column in datgridview
                dataGridView1.ColumnCount = 4;
                // auto size column
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //column properties
                dataGridView1.Columns[0].Name = "Id";
                dataGridView1.Columns[1].Name = "First Name";
                dataGridView1.Columns[2].Name = "Last Name";
                dataGridView1.Columns[3].Name = "Salary";
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                foreach (var item in staffSalary)
                {
                    dataGridView1.Rows.Add(item.EmployeeId, item.First_Name, item.Last_Name, item.Salary);
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Please Enter a valid Salary");
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button7.Enabled = true;
            dataGridView1.Rows.Clear();
            // create column in datgridview
            loadpage();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {

         
            // get selected id 
            var id = dataGridView1.SelectedCells[0].Value.ToString();

           // get dept tha match id
           var dept =  Process.GetDepartmentById(int.Parse(id));
            // new page 
            EditDepartment page = new EditDepartment(dept, Process);
            page.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Operation");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {

            // selected id from table
            var id = dataGridView1.SelectedCells[0].Value.ToString();
            // delete
            Process.DeleteDepartment(int.Parse(id));
            // reload department 
            dataGridView1.Rows.Clear();
            // create column in datgridview
            dataGridView1.ColumnCount = 2;
            // auto size column
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //column properties
            dataGridView1.Columns[0].Name = "Id";
            dataGridView1.Columns[1].Name = "Departments";
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            var allDepts = Process.Alldepartment();

                    foreach (var item in allDepts)
                    {

                        dataGridView1.Rows.Add(item.DepartmentId, item.Department_Name);
                    }


            }
            catch (Exception)
            {

                MessageBox.Show("invalid Operation");
            }

        }
    }
}
