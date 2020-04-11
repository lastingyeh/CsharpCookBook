using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch2
{
    public static class EX209
    {
        public static void CreateNestedObjects()
        {
            Group<Group<Item>> hierarchy =
                new Group<Group<Item>>("root")
                {
                    new Group<Item>("subgroup1")
                    {
                        new Item("item1",100),
                        new Item("item2",200)
                    },
                    new Group<Item>("subgroup2")
                    {
                        new Item("item3",300),
                        new Item("item4",400)
                    },
                };

            IEnumerator enumerator = ((IEnumerable)hierarchy).GetEnumerator();

            while (enumerator.MoveNext())
            {
                Group<Item> rootItem = (Group<Item>)enumerator.Current;

                Console.WriteLine(rootItem.Name);

                foreach (Item subItem in rootItem)
                    Console.WriteLine(subItem.Name);
            }

            DisplayNestedObjects(hierarchy);
        }

        private static void DisplayNestedObjects(Group<Group<Item>> topLevelGroup)
        {
            Console.WriteLine($"topLevelGroup.Count: {topLevelGroup.Count}");
            Console.WriteLine($"topLevelGroupName:  {topLevelGroup.Name}");

            foreach (Group<Item> subGroup in topLevelGroup)
            {
                Console.WriteLine($"\tsubGroup.SubGroupName:  {subGroup.Name}");
                Console.WriteLine($"\tsubGroup.Count:  {subGroup.Count}");

                foreach (Item item in subGroup)
                {
                    Console.WriteLine($"\t\titem.Name:   {item.Name}");
                    Console.WriteLine($"\t\titem.Location:  {item.Location}");
                }
            }
        }
    }
}
