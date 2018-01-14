using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using TalkingJournal.model;

namespace TalkingJournal.extractors
{
    public abstract class ContentExtractor
    {
        public abstract Content GetText(Stream stream, string xpath);
        public abstract Content GetText(string text,string xpath);
    }
}
