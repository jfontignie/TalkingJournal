using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TalkingJournal.extractors;

namespace TalkingJournal_Tests
{
    
    [TestClass]
    public class ExtractorTests
    {
        [TestMethod]
        public void TestContentExtractionTdg()
        {
            var stream = File.OpenRead("resources/tdg/sample.txt");
            var content = ArticleExtractor.Instance.GetText(stream,TestConstants.TdgXpath);
            Console.WriteLine(content);
        }

        
        [TestMethod]
        public void TestContentExtractionLeMonde()
        {
            var stream = File.OpenRead("resources/lemonde/sample.txt");
            var content = ArticleExtractor.Instance.GetText(stream,TestConstants.LeMondeXpath);
            Console.WriteLine(content);
        }
    }
}
