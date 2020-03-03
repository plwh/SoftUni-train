using P06_Twitter.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06_Twitter.Models
{
    public class Client : IClient
    {
        public Client()
        {
            this.Tweets = new List<ITweet>();
        }

        public IList<ITweet> Tweets { get; set; }

        public string ShowLastTweet()
        {
            if (this.Tweets.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.Tweets.Last().Message;
        }

        public string Tweet(ITweet tweet)
        {
            this.Tweets.Add(tweet);
            return this.ShowLastTweet();
        }
    }
}
