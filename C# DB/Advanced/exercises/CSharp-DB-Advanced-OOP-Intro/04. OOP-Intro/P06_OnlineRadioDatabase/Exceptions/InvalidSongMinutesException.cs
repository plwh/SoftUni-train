using System;
using System.Collections.Generic;
using System.Text;

namespace P06_OnlineRadioDatabase.Exceptions
{
    public class InvalidSongMinutesException : InvalidSongException
    {
        public override string Message => "Song minutes should be between 0 and 14.";
    }
}
