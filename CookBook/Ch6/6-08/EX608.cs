using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CookBook.Ch6
{
    public static class EX608
    {
        public static void Run()
        {
            dynamic expando = new ExpandoObject();
            expando.Name = "Brian";
            expando.Country = "USA";

            AddProperty(expando, "Language", "English");

            // add method
            expando.IsValid = (Func<bool>)(() =>
            {
                if (string.IsNullOrWhiteSpace(expando.Name))
                    return false;
                return true;
            });

            if (!expando.IsValid())
            {
                // Don't allow continuation...
            }

            // add event
            var eventHandler = new Action<object, EventArgs>((sender, eventArgs) =>
            {
                dynamic exp = sender as ExpandoObject;
                var langArgs = eventArgs as LanguageChangedEventArgs;
                Console.WriteLine($"Setting Language to : {langArgs?.Language}");
                exp.Language = langArgs?.Language;

            });
            // add LanguageChanged event
            AddEvent(expando, "LanguageChanged", eventHandler);
            // add CountryChanged event
            AddEvent(expando, "CountryChanged", new Action<object, EventArgs>((sender, eventArgs) =>
            {
                dynamic exp = sender as ExpandoObject;
                var ctryArgs = eventArgs as CountryChangedEventArgs;
                string newLanguage = string.Empty;

                switch (ctryArgs?.Country)
                {
                    case "France":
                        newLanguage = "French";
                        break;
                    case "China":
                        newLanguage = "Mandarin";
                        break;
                    case "Spain":
                        newLanguage = "Spanish";
                        break;
                }

                Console.WriteLine($"Country changed to {ctryArgs?.Country}, " +
                    $"changing Language to {newLanguage}");
                exp?.LanguageChanged(sender, new LanguageChangedEventArgs() { Language = newLanguage });
            }));

            ((INotifyPropertyChanged)expando).PropertyChanged +=
                new PropertyChangedEventHandler((sender, ea) =>
                {
                    dynamic exp = sender as dynamic;
                    var pcea = ea as PropertyChangedEventArgs;
                    if (pcea?.PropertyName == "Country")
                        exp.CountryChanged(exp, new CountryChangedEventArgs() { Country = exp.Country });
                });

            Console.WriteLine($"expando contains: {expando.Name}, {expando.Country}, " +
                $"{expando.Language}");
            Console.WriteLine();

            Console.WriteLine("Changing Country to France…");
            expando.Country = "France";
            Console.WriteLine($"expando contains: {expando.Name}, {expando.Country}, " +
                $"{expando.Language}");
            Console.WriteLine();

            Console.WriteLine("Changing Country to China…");
            expando.Country = "China";
            Console.WriteLine($"expando contains: {expando.Name}, {expando.Country}, " +
                $"{expando.Language}");
            Console.WriteLine();

            Console.WriteLine("Changing Country to Spain…");
            expando.Country = "Spain";
            Console.WriteLine($"expando contains: {expando.Name}, {expando.Country}, " +
                $"{expando.Language}");
            Console.WriteLine();

        }

        public static void AddEvent(ExpandoObject expando, string eventName,
            Action<object, EventArgs> handler)
        {
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(eventName))
                expandoDict[eventName] = handler;
            else
                expandoDict.Add(eventName, handler);
        }

        public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            var expandoDict = expando as IDictionary<string, object>;

            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }
    }
}
