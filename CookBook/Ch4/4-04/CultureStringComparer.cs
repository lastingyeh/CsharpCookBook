using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace CookBook.Ch4
{
    public class CultureStringComparer:IComparer<string>
    {
        public CultureInfo CurrentCultureInfo { get; set; }
        public CompareOptions Options { get; set; }

        private CultureStringComparer() { }
        public CultureStringComparer(CultureInfo cultureInfo, CompareOptions options)
        {
            if (cultureInfo == null)
                throw new ArgumentException(nameof(cultureInfo));
            CurrentCultureInfo = cultureInfo;
            Options = options;
        }

        public int Compare([AllowNull] string x, [AllowNull] string y) =>
            CurrentCultureInfo.CompareInfo.Compare(x, y, Options);
    }
}
