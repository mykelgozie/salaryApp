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
    public partial class DepartmentForm : Form
    {
        public IProcessInterface Getquery { get; set; }
        public DepartmentForm( IProcessInterface process)
        {
            InitializeComponent();
            Getquery = process;
        }
        // department textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // add department button
        private void button1_Click(object sender, EventArgs e)
        {
            var textValue =ValidateClass.CheckEmptyString(textBox1.Text);
            Getquery.AddDepartment(textValue);
            MessageBox.Show("Department Added");
            textBox1.Text = "";

        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
