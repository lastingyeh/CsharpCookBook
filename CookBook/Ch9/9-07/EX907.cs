using System;
namespace CookBook.Ch9
{
    public static class EX907
    {
        public static void Run()
        {
            string data = "<h1>My html</h1>";
            Console.WriteLine($"Original Data: {data}");
            Console.WriteLine();

            string escapedData = Uri.EscapeDataString(data);
            Console.WriteLine($"Escaped Data: {escapedData}");
            Console.WriteLine();

            string unescapedData = Uri.UnescapeDataString(escapedData);
            Console.WriteLine($"Unescaped Data: {unescapedData}");
            Console.WriteLine();

            string uriString = "http://user:password@localhost:8080/www.abc.com/" +
                "home page.htm?item=1233;html=<h1>Heading</h1>#stuff";
            Console.WriteLine($"Original Uri string: {uriString}");
            Console.WriteLine();

            string escapedUriString = Uri.EscapeUriString(uriString);
            Console.WriteLine($"Escaped Uri string: {escapedUriString}");
            Console.WriteLine();

            // Why not just use EscapeDataString to escape a Uri? It's not picky enough…
            string escapedUriData = Uri.EscapeDataString(uriString);
            Console.WriteLine($"Escaped Uri data: {escapedUriData}");
            Console.WriteLine();
            Console.WriteLine(Uri.UnescapeDataString(escapedUriString));
        }
    }
}
