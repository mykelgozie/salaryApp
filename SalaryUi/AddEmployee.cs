using SalaryApp.SalaryLib;
using SalaryApp.SalaryLib.Interface;
using SalaryApp.SalaryLib.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalaryApp.SalaryUi
{
    public partial class AddEmployee : Form
    {
        public IProcessInterface Getquery { get; set; }
        public AddEmployee(IProcessInterface process)
        {
            InitializeComponent();
            Getquery = process;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // telephone button
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        // last name button
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        // first name button
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // load form 
        private void AddEmployee_Load(object sender, EventArgs e)
        {
            var allDept = Getquery.Alldepartment();

            foreach (var item in allDept)
            {
                comboBox1.Items.Add(item.Department_Name);
            }

        }

        // department select box
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // add staff button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            // selcted item name
            var name = ValidateClass.CheckEmptyString(comboBox1.SelectedItem.ToString());

            // selected item name
            var id = Getquery.GetDepartmentId(name);
            var firstName = ValidateClass.CheckEmptyString(textBox1.Text);
            var lastName =  ValidateClass.CheckEmptyString(textBox2.Text);
            var telPhone = int.Parse(ValidateClass.CheckEmptyString(textBox4.Text));
            var email =  ValidateClass.CheckEmptyString(textBox6.Text);
            var salary = int.Parse(textBox5.Text);
            //todays date
            DateTime dateTime = DateTime.UtcNow;
            var hireDate = dateTime.ToString("dd/MM/yyyy");
            DateTime date = DateTime.Parse(hireDate);
            // add employee
            Getquery.AddEmployee(firstName, lastName, email, telPhone, date, salary, id);
            MessageBox.Show("New employee Added");
            // empty textbox
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Operation");
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        // salarty text
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
