using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TalkingJournal.model;
using Xamarin.Forms.Internals;

namespace TalkingJournal.services
{
    public class CategoryService
    {
        public static readonly CategoryService Instance = new CategoryService();

        private CategoryService()
        {
        }


        public async Task Update(Category category)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(category.UrlRss);
            if (response == null) return;

            var rss = response.Content.ReadAsStringAsync().Result;

            var rssFeed = RssService.Instance.Load(rss);
            foreach (var rssEntry in rssFeed)
            {
                var article = category
                    .Where(a => a.Title.Equals(rssEntry.Title))
                    .DefaultIfEmpty()
                    .First();

                if (article == null)
                {
                    article = new Article
                    {
                        Title = rssEntry.Title,
                        Link = rssEntry.Link,
                    };
                    category.AddArticle(article);
                }

                await LinkService.UpdateContentFromArticle(article);
            }

        }
    }
}