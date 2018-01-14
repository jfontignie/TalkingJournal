using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TalkingJournal.model
{
    public class Journal : IEnumerable<Category>
    {
        public string Title { get; set; }
        public string Xpath { get; set; }

        private readonly List<Category> _categories = new List<Category>();

        public void AddCategory(Category category)
        {
            if (_categories.Any(c => c == category)) return;
            _categories.Add(category);
            category.Journal = this;
        }

        #region Enumerator
        
        public IEnumerator<Category> GetEnumerator()
        {
            return _categories.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
        #endregion
    }
}
