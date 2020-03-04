using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Data
{
    public class Configuration
    {
        public static string ConnectionString => @"Server=(localdb)\v12.0;Database=EmployeesDb;Integrated Security=True";
    }
}
