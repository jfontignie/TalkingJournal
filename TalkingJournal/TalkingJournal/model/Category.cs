using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TalkingJournal.model
{
    public class Category : IEnumerable<Article>
    {
        public string Name { get; set; }
        public string UrlRss { get; set; }

        private string _xpath;

        public string Xpath
        {
            get => _xpath ?? Journal?.Xpath;
            set => _xpath = value;
        }

        private Journal _journal;
        public Journal Journal {
            get => _journal;

            set
            {
                if (value == _journal) return;
                _journal = value;
                _journal.AddCategory(this);
            }
        }

        private readonly List<Article> _articles = new List<Article>();

        public void AddArticle(Article article)
        {
            if (_articles.Any(a => a == article)) return;
            _articles.Add(article);
            article.Category = this;
        }

        #region Enumerator

        public IEnumerator<Article> GetEnumerator()
        {
            return _articles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}