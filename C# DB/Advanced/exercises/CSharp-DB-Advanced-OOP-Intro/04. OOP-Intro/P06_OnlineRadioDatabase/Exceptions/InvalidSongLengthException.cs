using System;
using System.Collections.Generic;
using System.Text;

namespace P06_OnlineRadioDatabase.Exceptions
{
    public class InvalidSongLengthException : InvalidSongException
    {
        public override string Message => "Invalid song length.";
    }
}
