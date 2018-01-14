using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using TalkingJournal.extractors;
using TalkingJournal.model;

namespace TalkingJournal.services
{
    public class LinkService
    {
        public static async Task UpdateContentFromArticle(Article article)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(article.Link);

            if (response == null) return;
            var text = response.Content.ReadAsStringAsync().Result;

            Content newContent;
            try
            {
                newContent = ArticleExtractor.Instance.GetText(text, article.Category.Xpath);
            }
            catch (Exception e)
            {
                throw new Exception("Impossible to read article: " + article.Link, e);
            }

            article.Content = newContent;
        }
    }
}