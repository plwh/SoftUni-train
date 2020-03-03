using System;
using System.Collections.Generic;
using System.Text;

public class Smartphone : ICallable, IBrowsable
{
    public void BrowseWebsite(string website)
    {
        Console.WriteLine($"Browsing: {website}!");
    }

    public void CallNumber(string number)
    {
        Console.WriteLine($"Calling... {number}");
    }
}
