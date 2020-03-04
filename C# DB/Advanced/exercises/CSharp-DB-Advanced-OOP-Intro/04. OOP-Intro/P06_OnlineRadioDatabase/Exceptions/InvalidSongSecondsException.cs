using System;
using System.Collections.Generic;
using System.Text;

namespace P06_OnlineRadioDatabase.Exceptions
{
    public class InvalidSongSecondsException : InvalidSongException
    {
        public override string Message => "Song seconds should be between 0 and 59.";
    }
}
