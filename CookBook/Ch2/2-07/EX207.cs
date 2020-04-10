using System;
namespace CookBook.Ch2
{
    public static class EX207
    {
        public static void Run()
        {
            Container<int> container = new Container<int>(){1,2,3,4,5,6,7,8,9,0};

            container.Display("Iterator");

            container.GetReverseOrderEnumerator().Display("Iterates reverse");

            container.GetForwardStepEnumerator(2).Display("Iterates by 2 steps");

            container.GetReverseStepEnumerator(2).Display("iterates reverse by 2 steps");
        }
    }
}
