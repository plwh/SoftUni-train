using System;
using System.Collections.Generic;
using System.Text;

public interface ITrafficLight
{
    Light Light { get; }

    void Cycle();
}
