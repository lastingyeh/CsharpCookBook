using System;
namespace CookBook.Ch5
{
    public enum CategoryType : short
    {
        None = 0,
        WriteToDB = 1,
        ReadFromDB = 2,
        WriteToFile = 3,
        ReadFromFile = 4,
        AppStartUp = 5,
        AppShutDown = 6,
        UserInput = 7
    }
}
