using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1
{
    public partial class GeneratedEntity
    {
        // Comment [ChangingProperty] implement

        partial void ChangingProperty(string name, string originalValue, string newValue)
        {
            Console.WriteLine($"Changed property ({name}) for entity {this.EntityName} from {originalValue} to {newValue}");
        }
    }
}
