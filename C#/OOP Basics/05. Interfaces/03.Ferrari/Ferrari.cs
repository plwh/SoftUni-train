using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari : ICar
{
    private string driverName;
    private const string model = "488-Spider";

    public Ferrari(string driverName)
    {
        this.DriverName = driverName;
    }

    public string Model
    {
        get { return model; }
    }

    public string DriverName
    {
        get { return driverName; }
        set { driverName = value; }
    }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public override string ToString()
    {
        return String.Format($"{this.Model}/{this.UseBrakes()}/{this.PushGasPedal()}/{this.DriverName}");
    }
}
