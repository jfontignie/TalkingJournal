using System;
using System.IO;
using System.Linq;
using HtmlAgilityPack;
using TalkingJournal.model;

namespace TalkingJournal.extractors
{
    public class ArticleExtractor : ContentExtractor
    {
        public static readonly ArticleExtractor Instance = new ArticleExtractor();

        private ArticleExtractor()
        {

        }

        public override Content GetText(Stream stream, string xpath)
        {
            var document = new HtmlDocument();
            document.Load(stream);
            return Process(document,xpath);
        }

        public override Content GetText(string text, string xpath)
        {
            
            var document = new HtmlDocument();
            document.LoadHtml(text);
            return Process(document,xpath);
        }

        private static Content Process(HtmlDocument document, string xpath)
        {

            if (xpath == null) throw new Exception("The xpath has not been specified");

            var found = document.DocumentNode.SelectNodes(
               xpath)
                .Where(n => !n.InnerText.Trim('\r','\n').Trim().Equals(""));
            
            var content = new Content();
            foreach (var paragraph in found)
            {
                content.AddChapter(paragraph.InnerText);
            }
            return content;
        }
    }

    }
