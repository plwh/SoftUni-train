using System;
using System.Collections.Generic;
using System.Text;

namespace P04_WorkForce.Models
{
    public class StandardEmployee : Employee
    {
        public StandardEmployee(string name) 
            : base(name, 40) { }
    }
}
