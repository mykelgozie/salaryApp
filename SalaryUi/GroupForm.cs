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
    public partial class GroupForm : Form
    {
        public  IProcessInterface Getquery { get; set; }
        public GroupForm(IProcessInterface process)
        {
            InitializeComponent();
            Getquery = process;
        }
        // dispaly text box 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // group  all items by department  
        private void GroupForm_Load(object sender, EventArgs e)
        {
            var conn = DatabaseProcessClass.OpenConnection();
           var result =  Getquery.GroupByDept();

            // get
            var table = "\r\n";
            foreach (var item in result)
            {
                table += "\r\n" + item.Key +"\r\n" + "\r\n";

                foreach (var employe in item)
                {
                    table += employe.First_Name + "  " + employe.Last_Name + "  "+ employe.Department.Department_Name  + "\r\n";

                }
                
            }

            textBox1.Text = table;

        }
    }
}
