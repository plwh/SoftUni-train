using System;
using System.Collections.Generic;
using System.Text;

namespace P06_OnlineRadioDatabase.Exceptions
{
    public class InvalidSongException : Exception
    {
        private string exceptionMessage = "Invalid song.";

        protected virtual string ExceptionMessage
        {
            set
            {
                exceptionMessage = value;
            }
        }

        public override string Message => exceptionMessage;
    }
}
