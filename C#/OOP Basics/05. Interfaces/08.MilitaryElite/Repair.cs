using System;
using System.Collections.Generic;
using System.Text;

public class Repair : IRepair
{
    public Repair(string partName, int hoursWorked)
    {
        this.PartName = partName;
        this.HoursWorkded = hoursWorked;
    }
    public string PartName { get; private set; }

    public int HoursWorkded { get; private set; }

    public override string ToString()
    {
        return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorkded}";
    }
}
