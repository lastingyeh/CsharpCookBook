using System;
using System.Diagnostics;
using System.Threading;

namespace CookBook.Ch4
{
    public class Recipe
    {
        public RecipeChapter Chapter { get; set; }
        public string MainIngredient { get; set; }
        public int Number { get; set; }
        public bool TextApproved { get; set; }
        public bool IngredientsApproved { get; set; }

        public int RecipeEvaluated { get; set; }
        public bool FinalEditingComplete { get; set; }
        public int Rank { get; set; }
        public override string ToString() =>
            $"{Chapter.Number}.{Number} ({Chapter.Title}:{MainIngredient})";

        private static Recipe EvaluateRecipe(Recipe r, Random rnd)
        {
            if (!r.TextApproved)
            {
                Thread.Sleep(50);
                int evaluation = rnd.Next(1, 10);

                if(evaluation == 7)
                {
                    Console.WriteLine($"{r} failed the readthrough! Reworking...");
                }
                else
                {
                    r.TextApproved = true;
                }
                return EvaluateRecipe(r, rnd);
            }
            else if (!r.IngredientsApproved)
            {
                Thread.Sleep(100);
                int evaluaton = rnd.Next(1, 10);

                if(evaluaton == 3)
                {
                    Console.WriteLine($"{r} had incorrect measurements! Reworking...");
                }
                else
                {
                    r.IngredientsApproved = true;
                }
                return EvaluateRecipe(r, rnd);
            }
            else if(r.RecipeEvaluated != r.Rank)
            {
                Thread.Sleep(50 * r.Rank);
                int evaluation = rnd.Next(1, 10);

                if(evaluation == 4)
                {
                    r.TextApproved = false;
                    r.IngredientsApproved = false;
                    r.RecipeEvaluated = 0;
                    Console.WriteLine($"{r} tasted bad!  Reworking...");
                }
                else
                {
                    r.RecipeEvaluated++;
                }
                return EvaluateRecipe(r, rnd);
            }
            else
            {
                Thread.Sleep(50 * r.Rank);
                int evaluation = rnd.Next(1, 10);
                if(evaluation == 1)
                {
                    r.TextApproved = false;
                    r.IngredientsApproved = false;
                    r.RecipeEvaluated = 0;
                    Console.WriteLine($"{r} failed final editing!  Reoworking...");
                    return EvaluateRecipe(r, rnd);
                }
                r.FinalEditingComplete = true;
                Console.WriteLine($"{r} is ready for release!");
            }
            return r;
        }

        private static RecipeChapter TimedEvaluateChapter(RecipeChapter rc, Random rnd)
        {
            Stopwatch watch = new Stopwatch();
            Console.WriteLine($"Evaluating Chapter {rc}");
            watch.Start();
            foreach (var r in rc.Recipes)
            {
                EvaluateRecipe(r, rnd);
            }
            watch.Stop();
            Console.WriteLine($"Finished Evaluating Chapter {rc}");
            return rc;
        }
    }
}
