using P06_Twitter.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Twitter.Models
{
    public class Tweet : ITweet
    {
        public Tweet(string message)
        {
            if(string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException();
            }

            if(message.Length > 255)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Message = message;
        }

        public string Message { get; set; }
    }
}
