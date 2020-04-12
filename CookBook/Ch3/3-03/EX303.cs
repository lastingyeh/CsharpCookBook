using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch3
{
    public static class EX303
    {
        public static void Run()
        {
            // ASCII to string
            // 128 convert to "?" => "?Source String?"
            byte[] asciiCharacterArray = { 128, 83, 111, 117, 114, 99, 101, 32, 83, 116, 114, 105, 110, 103, 128 };

            string asciiCharacters = Encoding.ASCII.GetString(asciiCharacterArray);
            Console.WriteLine(asciiCharacters);

            // Unicode to string 
            // Source Sting
            byte[] unicodeCharacterArray = { 128, 0, 83, 0, 111, 0, 117, 0, 114, 0, 99, 0, 101, 0, 32, 0, 83, 0, 116, 0, 114, 0, 105, 0, 110, 0, 103, 0, 128, 0 };

            string unicodeCharacters = Encoding.Unicode.GetString(unicodeCharacterArray);
            Console.WriteLine(unicodeCharacters);
        }
    }
}
