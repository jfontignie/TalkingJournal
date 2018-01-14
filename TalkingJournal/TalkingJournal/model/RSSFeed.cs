using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TalkingJournal.model
{
    public class RssFeed : IEnumerable<RssEntry>
    {
        public string Title { get; }
        private readonly List<RssEntry> _entries = new List<RssEntry>();

        public RssFeed(string title)
        {
            Title = title;
        }

        public void Add(RssEntry entry)
        {
            _entries.Add(entry);
        }

        #region Enumerator

        public IEnumerator<RssEntry> GetEnumerator()
        {
            return _entries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        #endregion
        
        public override string ToString()
        {
            return _entries.Select(r => r.ToString()).Aggregate((current,next) => current + "," + next);
        }
    }

    public class RssEntry
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

        public override string ToString()
        {
            return "[title=" + Title + ", description=" + Description + ",link=" + Link + "]";
        }
    }
}