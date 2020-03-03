using System;
using System.Collections.Generic;
using System.Text;

namespace P09_DateTime.Tests
{
    public interface IClock
    {
        DateTime Now { get; set; }
    }
}
