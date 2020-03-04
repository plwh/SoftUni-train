﻿using System;
using System.Collections.Generic;
using System.Text;

public class DriverFactory
{
    public Driver CreateDriver(string driverType, string driverName, Car car)
    {
        Driver driver = null;

        if (driverType == "Aggressive")
        {
            driver = new AggressiveDriver(driverName, car);
            return driver;
        }
        else if (driverType == "Endurance")
        {
            driver = new EnduranceDriver(driverName, car);
            return driver;
        }

        throw new ArgumentException(OutputMesages.InvalidDriverType);
    }
}