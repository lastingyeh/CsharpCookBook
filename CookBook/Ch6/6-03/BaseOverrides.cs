using System;
namespace CookBook.Ch6
{
    public abstract class BaseOverrides
    {
        public abstract void Foo(string str, int i);
        public abstract void Foo(long l, double d, byte[] bytes);
    }

    public class DerivedOverrides : BaseOverrides
    {
        public override void Foo(string str, int i)
        {
          
        }

        public override void Foo(long l, double d, byte[] bytes)
        {
            
        }
    }
}
