using System;
using System.Configuration;

namespace CookBook.Ch4
{
    public class EditionElementCollection : ConfigurationElementCollection
    {
        public EditionElementCollection()
        {
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new EditionElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EditionElement)element).Number;
        }
    }
}
