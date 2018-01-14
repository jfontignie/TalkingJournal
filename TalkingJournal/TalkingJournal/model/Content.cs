using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TalkingJournal.model
{
    public class Content : IEnumerable<string>
    {
        private readonly List<string> _chapters = new List<string>();

        public void AddChapter(string chapter)
        {
            var trimmed = chapter.Trim('\n', '\r').Trim();
            if (trimmed.Equals("")) return;
            _chapters.Add(trimmed);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _chapters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return _chapters.Aggregate((current, next) => current + "\n" + next);
        }
    }
}