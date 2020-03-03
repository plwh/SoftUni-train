using System;
using System.Collections.Generic;
using System.Text;

namespace P04_WorkForce.Contracts
{
    public interface IEmployee : INameable
    {
        int WorkHoursPerWeek { get; }
    }
}
