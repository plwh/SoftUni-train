using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using P06_Twitter.Contracts;
using P06_Twitter.Models;

namespace P06_Twitter.Tests
{
    [TestFixture]
    public class TwitterTests
    {
        private IClient client;

        [SetUp]
        public void TestInit()
        {
            this.client = new Client();
        }

        [Test]
        public void TweetMessage()
        {
            this.client.Tweet(new Tweet("Test tweet"));

            Assert.Pass();
        }

        [Test]
        public void TweetEmptyMessageShouldThrow()
        {
            Assert.That(() => this.client.Tweet(new Tweet(string.Empty)), Throws.ArgumentNullException);
        }

        [Test]
        public void TweetTextOverLimitShouldThrow()
        {
            Assert.That(() => this.client.Tweet(new Tweet(new string('+', 257))), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void ClientStoresTweet()
        {
            this.client.Tweet(new Tweet("Hello"));

            Assert.That(this.client.Tweets.Count, Is.EqualTo(1));
        }

        [Test]
        public void ClientReturnsTweetMessage()
        {
            string result = this.client.Tweet(new Tweet("Guten tag"));

            Assert.That("Guten tag", Is.EqualTo(result));
        }

        [Test]
        public void DisplayLastTweet()
        {
            this.client.Tweet(new Tweet("One"));
            this.client.Tweet(new Tweet("Two"));
            this.client.Tweet(new Tweet("Three"));

            string result = this.client.ShowLastTweet();

            Assert.That("Three", Is.EqualTo(result));
        }

        [Test]
        public void DisplayLastTweetEmptyTweetsListShouldThrow()
        {
            Assert.That(() => this.client.ShowLastTweet(), Throws.InvalidOperationException);
        }
    }
}
