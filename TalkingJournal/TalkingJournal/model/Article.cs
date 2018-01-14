using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using TalkingJournal.model;

namespace TalkingJournal
{
    public class Article
    {
        private Content _content;
        private bool _isSet;


        public string Title { get; set; } = "";
        public string Link { get; set; } = "";

        private Category _category;
        public Category Category
        {
            get { return _category; }
            set
            {
                if (_category != value)
                {
                    _category = value;
                    _category.AddArticle(this);
                }
            }
        }

        public Content Content
        {
            get
            {
                if (!_isSet) throw new Exception("The content has not been specified");
                return _content;
            }
            set
            {
                _isSet = true;
                _content = value;
            }
        }
    }
}