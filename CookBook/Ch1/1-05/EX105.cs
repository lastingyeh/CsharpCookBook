using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBook.Ch1
{
    public static class EX105
    {
        public static void Run(string[] argumentStrings)
        {
            var arguments = (from argument in argumentStrings
                             select new Argument(argument)).ToArray();

            Console.WriteLine("Command line: ");
            foreach (Argument a in arguments)
            {
                Console.WriteLine($"{a.Original}");
            }
            Console.WriteLine("");

            ArgumentSemanticAnalyzer analyzer = new ArgumentSemanticAnalyzer();

            analyzer.AddArgumentVerifier(
                new ArgumentDefinition("output",
                "/output:[path to output]",
                "Specifies the location of the output file.",
                x => x.IsCompoundSwitch));

            analyzer.AddArgumentVerifier(
                new ArgumentDefinition("trialMode",
                "/trialmode",
                "If this is specified it places the product into trial mode",
                x => x.IsSimpleSwitch));

            analyzer.AddArgumentVerifier(
                new ArgumentDefinition("DEBUGOUTPUT",
                "/debugoutput:[value1];[value2];[value3]",
                "A listing of the files the debug output" +
                "information will be written to",
                x => x.IsComplexSwitch));

            analyzer.AddArgumentVerifier(
                new ArgumentDefinition("",
                "[literal value]",
                "A literal value",
                x => x.IsSimple));

            if (!analyzer.verifyArguments(arguments))
            {
                string invalidArguments = analyzer.InvalidArgumentsDisplay();
                Console.WriteLine(invalidArguments);
                ShowUsage(analyzer);

                return;
            }

            string output = string.Empty;
            bool trialmode = false;
            IEnumerable<string> debugOutput = null;
            List<string> literals = new List<string>();

            analyzer.AddArgumentAction("OUTPUT", x => { output = x.SubArguments[0]; });
            analyzer.AddArgumentAction("TRIALMODE", x => { trialmode = true; });
            analyzer.AddArgumentAction("DEBUGOUTPUT", x => { debugOutput = x.SubArguments; });
            analyzer.AddArgumentAction("", x => { literals.Add(x.Original); });

            analyzer.EvaluateArguments(arguments);

            Console.WriteLine("");
            Console.WriteLine($"OUTPUT: {output}");
            Console.WriteLine($"TRIALMODE: {trialmode}");

            if (debugOutput != null)
            {
                foreach (string item in debugOutput)
                {
                    Console.WriteLine($"DEBUGOUTPUT: {item}");
                }
            }

            foreach (string literal in literals)
            {
                Console.WriteLine($"LITERAL: {literal}");
            }
        }

        public static void ShowUsage(ArgumentSemanticAnalyzer analyzer)
        {
            Console.WriteLine("Program.exe allows the following arguments:");
            foreach (ArgumentDefinition definition in analyzer.ArgumentDefinitions)
            {
                Console.WriteLine($"\t{definition.ArgumentSwitch}:" +
                    $"({definition.Description}){Environment.NewLine}\tSyntax: {definition.Syntax}");
            }
        }
    }
}
