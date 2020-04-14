using System;
using System.Configuration;

namespace CookBook.Ch4
{
    public class EditionElement : ConfigurationElement
    {
        [ConfigurationProperty("Number", IsRequired = true)]
        public string Number
        {
            get { return this["Number"].ToString(); }
            set { this["Number"] = value; }
        }

        [ConfigurationProperty("PublicationYear", IsRequired = true)]
        public string PublicationYear
        {
            get { return this["PublicationYear"].ToString(); }
            set { this["PublicationYear"] = value; }
        }

        public EditionElement(){}
    }
}
