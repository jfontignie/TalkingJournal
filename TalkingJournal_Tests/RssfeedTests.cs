using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingJournal.services;

namespace TalkingJournal_Tests
{
    
    [TestClass]
    public class RssFeedTests
    {
        [TestMethod]
        public void TestRssRead()
        {
            var stream = File.OpenRead("resources/sample.rss");
            var feed = RssService.Instance.Load(stream);
            Console.WriteLine(feed);
        }
    }
}
