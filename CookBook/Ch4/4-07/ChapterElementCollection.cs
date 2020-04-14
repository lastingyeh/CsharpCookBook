using System;
using System.Configuration;

namespace CookBook.Ch4
{
    public class ChapterElementCollection : ConfigurationElementCollection
    {
        public ChapterElementCollection(){}

        protected override ConfigurationElement CreateNewElement()
        {
            return new ChapterElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ChapterElement)element).Number;
        }
    }
}
