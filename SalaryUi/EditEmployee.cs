using SalaryApp.SalaryLib;
using SalaryApp.SalaryLib.Interface;
using SalaryApp.SalaryLib.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalaryApp.SalaryUi
{
    public partial class EditEmployee : Form
    {
        public int EmployeId { get; set; }
        public IProcessInterface Getprocess { get; set; }
        public EditEmployee(int id, IProcessInterface process)
        {
            InitializeComponent();
            EmployeId = id;

          var employee  =  process.GetEmployeeWithId(id);

            textBox1.Text = employee.First_Name;
            textBox2.Text = employee.Last_Name;
            textBox3.Text = employee.Email;
            textBox4.Text = employee.Salary.ToString();
            textBox5.Text = employee.Phone_Number.ToString();


            var allDept = process.Alldepartment();

            foreach (var item in allDept)
            {
                comboBox1.Items.Add(item.Department_Name);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // last name textbox
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        // first name text box
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // email textbox
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        // update button 

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {      

            // selected department name 
            var name = comboBox1.SelectedItem.ToString();
            var id = Getprocess.GetDepartmentId(name);
            var firstName = ValidateClass.CheckEmptyString(textBox1.Text);
            var lastName = ValidateClass.CheckEmptyString(textBox2.Text);
            var telPhone = int.Parse(ValidateClass.CheckEmptyString(textBox5.Text));
            var email = ValidateClass.CheckEmptyString(textBox3.Text);
            var salary = int.Parse(textBox4.Text);
            // todays date 
            DateTime dateTime = DateTime.UtcNow;
            var hireDate = dateTime.ToString("dd/MM/yyyy");
            DateTime date = DateTime.Parse(hireDate);
            // update employee
            Getprocess.EmployeeUpdate(firstName,lastName,email,telPhone,date,salary,id,EmployeId);
            MessageBox.Show("Employee Edited");

            }
            catch (Exception)
            {

                MessageBox.Show("Invalid operation ");
            }
        }
        // select box
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
