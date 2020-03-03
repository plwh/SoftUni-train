using System;
using System.Collections.Generic;
using System.Text;

namespace P06_Twitter.Contracts
{
    public interface IClient
    {
        IList<ITweet> Tweets { get; set; }

        string Tweet(ITweet tweet);

        string ShowLastTweet();
    }
}
