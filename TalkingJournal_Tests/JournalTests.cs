using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingJournal.model;
using TalkingJournal.services;

namespace TalkingJournal_Tests
{
    [TestClass]
    public class JournalTests
    {
        [TestMethod]
        public void TestJournal()
        {
            Assert.IsNotNull(TestConstants.Tdg);

        }
    }
}