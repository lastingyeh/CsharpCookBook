using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1.TestSort
{
    public class CompareHeight : IComparer<Square>
    {
        public int Compare(object firstSquare, object secondSquare)
        {
            Square square1 = firstSquare as Square;
            Square square2 = secondSquare as Square;

            if (square1 == null || square2 == null)
                throw new ArgumentException("Both parameters must be of type Square.");

            return Compare(firstSquare, secondSquare);
        }

        #region IComparer<Square> Members

        public int Compare(Square x, Square y)
        {
            if (x.Height == y.Height)
                return 0;

            if (x.Height > y.Height)
                return 1;

            if (x.Height < y.Height)
                return -1;

            return -1;
        }
        #endregion
    }
}
