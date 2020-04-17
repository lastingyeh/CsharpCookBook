using System;
using System.Collections;

namespace CookBook.Ch5
{
    public static class EX506
    {
        public static void Run()
        {
            TestNestedDataException();

            TestExceptionDataSerializable();
        }

        public static void TestNestedDataException()
        {
            try
            {
                try
                {
                    try
                    {
                        try
                        {
                            ArgumentException irritable =
                                new ArgumentException("I'm irritable!");
                            irritable.Data["Cause"] = "Computer crashed";
                            irritable.Data["Length"] = 10;
                            throw irritable;
                        }
                        catch (Exception e)
                        {
                            if (e.Data.Contains("Cause"))
                                e.Data["Cause"] = "Fixed computer";
                            throw;
                        }
                    }
                    catch (Exception e)
                    {
                        e.Data["Comment"] = "Always grumpy you are";
                        throw;
                    }
                }
                catch (Exception e)
                {
                    e.Data["Reassurance"] = "Error Handled";
                    throw;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception support data:");
                foreach (DictionaryEntry de in e.Data)
                {
                    Console.WriteLine("\t{0} : {1},", de.Key, de.Value);
                }
            }
        }

        public static void TestExceptionDataSerializable()
        {
            Exception badMonkey = new Exception("You are a bad monkey");

            try
            {
                badMonkey.Data["Details"] = new Monkey();
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
        }
    }
}
