using System;
namespace CookBook.Ch5
{
    public enum EventIDType
    {
        NA = 0,
        Read = 1,
        Write = 2,
        ExceptionThrown = 3,
        BufferOverflowCondition = 4,
        SecurityFailure = 5,
        SecurityPotentiallyCompromised = 6
    }
}
