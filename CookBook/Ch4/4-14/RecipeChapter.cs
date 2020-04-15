using System;
using System.Collections.Generic;

namespace CookBook.Ch4
{
    public class RecipeChapter
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public List<Recipe> Recipes { get; set; }
        public override string ToString() => $"{Number} - {Title}";        
    }
}
