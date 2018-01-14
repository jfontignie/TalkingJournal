using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingJournal.model;
using TalkingJournal.services;

namespace TalkingJournal_Tests
{
    
    [TestClass]
    public class CatgoryServiceTests
    {
        //Too long [TestMethod]
        public void TestTDGCategoryLoad()
        {
            var category = TestConstants.Tdg.First();
            
            CategoryService.Instance.Update(category).Wait();
            var count1 = category.Count();
            CategoryService.Instance.Update(category).Wait();
            Assert.AreNotEqual(count1,0);
            Assert.AreNotEqual(count1*2,category.Count());
        }

        //Too long [TestMethod]
        public void TestLeMondeCategoryLoad()
        {
            var category = TestConstants.LeMonde.First();
            CategoryService.Instance.Update(category).Wait();
            var count1 = category.Count();
            CategoryService.Instance.Update(category).Wait();
            Assert.AreNotEqual(count1,0);
            Assert.AreNotEqual(count1*2,category.Count());
        }

    }
}
