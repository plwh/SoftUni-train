using System;
using System.Collections.Generic;
using System.Text;

public interface IRepair
{
    string PartName { get; }
    int HoursWorkded { get; }
}
