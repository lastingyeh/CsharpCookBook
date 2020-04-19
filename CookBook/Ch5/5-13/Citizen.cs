using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CookBook.Ch5
{
    [DebuggerDisplay("Citizen Full Name = {Honorific}{First}{Middle}{Last}")]
    public class Citizen
    {
        public string Honorific { get; set; }
        public string First { get; set; }
        public string  Middle { get; set; }
        public string Last { get; set; }
    }
}
