using System;
namespace CookBook.Ch6
{
    public class DynamicAthlete : DynamicBase<DynamicAthlete>
    {
        public string Name { get; set; }
        public string Sport { get; set; }
    }
}
