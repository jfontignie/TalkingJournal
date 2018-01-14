using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using TalkingJournal.model;

namespace TalkingJournal.services
{
    public class RssService
    {
        public static readonly RssService Instance = new RssService();

        private RssService()
        {
        }

        public RssFeed Load(string text)
        {
            var document = new XmlDocument();
            document.LoadXml(text);
            return Process(document);
        }

        public RssFeed Load(Stream stream)
        {
            var document = new XmlDocument();
            document.Load(stream);
            return Process(document);
        }

        private static RssFeed Process(XmlDocument document)
        {
            var feed = new RssFeed(GetTitle(document));
            var items = document.GetElementsByTagName("item");

            foreach (XmlNode item in items)
            {
                var title = item["title"].InnerText;
                var description = item["description"].InnerText;
                var link = item["link"].InnerText;
                feed.Add(new RssEntry
                    {
                        Title = title,
                        Description = description,
                        Link = link
                    }
                );
            }

            return feed;
        }

        private static string GetTitle(XmlDocument document)
        {
            var nodes =  document.GetElementsByTagName("title");
            return nodes.Count == 0 ? "unknown" : nodes[0].InnerText;
        }
    }
}