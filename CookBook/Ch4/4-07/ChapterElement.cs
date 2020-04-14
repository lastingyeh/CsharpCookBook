using System;
using System.Configuration;

namespace CookBook.Ch4
{
    public class ChapterElement : ConfigurationElement
    {
        [ConfigurationProperty("Number", IsRequired = true)]
        public string Number
        {
            get { return this["Number"].ToString(); }
            set { this["Number"] = value; }
        }

        [ConfigurationProperty("Title", IsRequired = true)]
        public string Title
        {
            get { return this["Title"].ToString(); }
            set { this["Title"] = value; }
        }

        public ChapterElement()
        {
        }

        
    }
}
