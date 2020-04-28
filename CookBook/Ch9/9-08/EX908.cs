using System;
using System.DirectoryServices;
using System.Linq;

namespace CookBook.Ch9
{
    public static class EX908
    {
        const string WebServerSchema = "IIsWebServer";

        public static void Run()
        {
            string server = "localhost";

            using (DirectoryEntry w3svc = new DirectoryEntry($"IIS://{server}/w3svc",
                "Domain/UserCode", "Password"))
            {
                WithLINQ(w3svc);

            }
        }

        private static void WithLINQ(DirectoryEntry w3svc)
        {
            var httpErrors = from site in w3svc?.Children.OfType<DirectoryEntry>()
                             where site.SchemaClassName == WebServerSchema
                             from siteDir in site.Children.OfType<DirectoryEntry>()
                             where siteDir.Name == "ROOT"
                             from httpError in siteDir.Properties["HttpErrors"].OfType<string>()
                             select httpError;
            // explicit dot notation syntax
            // httpErrors = w3svc?.Children.OfType<DirectoryEntry>()
            //    .Where(site => site.SchemaClassName == WebServerSchema)
            //    .SelectMany(siteDir => siteDir.Children.OfType<DirectoryEntry>())
            //    .Where(siteDir => siteDir.Name == "ROOT")
            //    .SelectMany<DirectoryEntry, string>(siteDir =>
            //    siteDir.Properties["HttpErrors"].OfType<string>());

            string[] errors = httpErrors.ToArray();
            foreach (var httpError in errors)
            {
                string[] errorParts = httpError.ToString().Split(',');
                Console.WriteLine("Error Mapping Entry:");
                Console.WriteLine($"\tHTTP error code: {errorParts[0]}");
                Console.WriteLine($"\tHTTP sub-error code: {errorParts[1]}");
                Console.WriteLine($"\tMessage Type: {errorParts[2]}");
                Console.WriteLine($"\tPath to error HTML file: {errorParts[3]}");
            }
        }

        private static void WithoutLINQ(DirectoryEntry w3svc)
        {
            foreach (DirectoryEntry site in w3svc?.Children)
            {
                if (site != null)
                {
                    using (site)
                    {
                        if (site.SchemaClassName == WebServerSchema)
                        {
                            string metabaseDir = $"/w3svc/{site.Name}/ROOT";

                            if (site.Children != null)
                            {
                                // find the ROOT directory for each server
                                foreach (DirectoryEntry root in site.Children)
                                {
                                    using (root)
                                    {
                                        if (root?.Name.Equals("ROOT",
                                            StringComparison.OrdinalIgnoreCase) ?? false)
                                        {
                                            if (root?.Properties.Contains("HttpErrors") == true)
                                            {
                                                PropertyValueCollection httpErrors =
                                                    root?.Properties["HttpErrors"];

                                                for (int i = 0; i < httpErrors?.Count; i++)
                                                {
                                                    string[] errorParts =
                                                        httpErrors?[i].ToString().Split(',');

                                                    Console.WriteLine("Error Mapping Entry:");
                                                    Console.WriteLine($"\tHTTP error code: {errorParts[0]}");
                                                    Console.WriteLine($"\tHTTP sub-error code: {errorParts[1]}");
                                                    Console.WriteLine($"\tMessage Type: {errorParts[2]}");
                                                    Console.WriteLine($"\tPath to error HTML file: {errorParts[3]}");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
