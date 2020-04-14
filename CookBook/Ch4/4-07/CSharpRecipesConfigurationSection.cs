using System;
using System.Collections.Generic;
using System.Configuration;

namespace CookBook.Ch4
{
    public class CSharpRecipesConfigurationSection : ConfigurationSection
    {
        public CSharpRecipesConfigurationSection() { }
        
        [ConfigurationProperty("CurrentEdition", IsRequired = false)]
        public string CurrentEdition
        {
            get { return this["CurrentEdition"].ToString(); }
            set { this["CurrentEdition"] = value; }
        }

        [ConfigurationProperty("Chapters", IsDefaultCollection = false)]
        public ChapterElementCollection Chapters
        {
            get { return this["Chapters"] as ChapterElementCollection; }
        }

        [ConfigurationProperty("Editions", IsDefaultCollection = false)]
        public EditionElementCollection Editions
        {
            get { return this["Editions"] as EditionElementCollection; }
        }

    }
}
