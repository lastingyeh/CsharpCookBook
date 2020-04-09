using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1.ReturnDimensions
{
    public class EX14
    {
        // Multiple return values
        public void Run()
        {
            int height;
            int width;
            int depth;

            ReturnDimensions(1, out height, out width, out depth);

            Dimensions dimensions = ReturnDimensions(1);

            Tuple<int, int, int> objDim = ReturnDimensionsAsTuple(1);
        }
        #region [Method1]- out variable 
        public void ReturnDimensions(int inputShape, out int height, out int width, out int depth)
        {
            height = 0;
            width = 0;
            depth = 0;
        }
        #endregion

        #region [Method2]- struct obj

        public struct Dimensions
        {
            public int Height;
            public int Width;
            public int Depth;
        }
        public Dimensions ReturnDimensions(int inputShape)
        {
            Dimensions dimensions = new Dimensions();

            return dimensions;
        }
        #endregion

        #region [Method3] Tuple
        public Tuple<int, int, int> ReturnDimensionsAsTuple(int inputShape)
        {
            var objDim = Tuple.Create<int, int, int>(5, 10, 15);

            return objDim;
        }
        #endregion
    }
}
