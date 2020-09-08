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
    public partial class EditDepartment : Form
    {
        public DepartmentClass DeptClass { get; set; }
        public IProcessInterface  processQuery { get; set; }

        public int DeptId { get; set; }
        public EditDepartment(DepartmentClass dept, IProcessInterface deptprocess )
        {
            InitializeComponent();



            DeptClass = dept;
            textBox1.Text = dept.Department_Name;
            processQuery = deptprocess;
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var deptName = ValidateClass.CheckEmptyString(textBox1.Text);
            processQuery.UpdatDepartment(DeptClass.DepartmentId, deptName);
            MessageBox.Show("Department Updated ");

        }
    }
}
