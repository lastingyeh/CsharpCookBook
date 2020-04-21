using System;
namespace CookBook.Ch6
{
    public class CountryChangedEventArgs : EventArgs
    {
        public string Country { get; set; }
    }
}
