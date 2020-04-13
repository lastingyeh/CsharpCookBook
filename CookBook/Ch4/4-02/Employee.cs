using System;
namespace CookBook.Ch4
{
    public class Employee
    {
        public string Name { get; set; }
        public override string ToString() => this.Name;
        public override bool Equals(object obj) => this.GetHashCode().Equals(obj.GetHashCode());
        public override int GetHashCode() => this.Name.GetHashCode();     
    }
}
