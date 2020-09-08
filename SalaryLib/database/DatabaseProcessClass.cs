using SalaryApp.SalaryLib.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryApp.SalaryLib.database
{
    public class DatabaseProcessClass 
    {
        // open connection 
        public static DatabaseClass OpenConnection()
        {
            var table = new DatabaseClass();
            return table;
        }
       
      
    }
}
