using System;
using System.Configuration;
using System.Linq;

namespace CookBook.Ch4
{
    public static class EX407
    {
        public static void Run()
        {
            var section = ConfigurationManager.GetSection("CSharpRecipesConfiguration") as
                CSharpRecipesConfigurationSection;

            var publicYear = (from edition in section.Editions.OfType<EditionElement>()
                             where edition.Number == section.CurrentEdition
                             select edition.PublicationYear).First();

            var expr = from chapter in section.Chapters.OfType<ChapterElement>()
                       where chapter.Title.Contains("and") && ((int.Parse(chapter.Number) % 2) == 0)
                       select new
                       {
                           ChapterNumber = $"Chapter {chapter.Number}",
                           chapter.Title,
                           publicYear
                       };

          

            foreach (var chapterInfo in expr)
                Console.WriteLine($"{chapterInfo.ChapterNumber} : {chapterInfo.Title} ({chapterInfo.publicYear})");
                         
        }
    }
}
