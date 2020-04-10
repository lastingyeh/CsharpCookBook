using System;

namespace CookBook.Ch1
{
    // Struct with an overload constructor
    public struct Data1
    {
        public int IntData { get; }
        public float FloatData { get; }
        public string StrData { get; }
        public char CharData { get; }
        public bool BoolData { get; }

        public Data1(int intData, float floatData,
            string strData, char charData, bool boolData)
        {
            IntData = intData;
            FloatData = floatData;
            StrData = strData;
            CharData = charData;
            BoolData = boolData;
        }

        public override string ToString() =>
            IntData + " :: " + FloatData + " :: " + StrData + " :: " + CharData + " :: " + BoolData;
    }

    // Stuct with optional arguments in the constructor
    public struct Data2
    {
        public int IntData { get; }
        public float FloatData { get; }
        public string StrData { get; }
        public char CharData { get; }
        public bool BoolData { get; }

        public Data2(int intData, float floatData = 1.1f,
            string strData = "a", char charData = 'a', bool boolData = true):this()
        {
            IntData = intData;
            FloatData = floatData;
            StrData = strData;
            CharData = charData;
            BoolData = boolData;
        }

        public override string ToString() =>
            IntData + " :: " + FloatData + " :: " + StrData + " :: " + CharData + " :: " + BoolData;
    }

    public struct Data3
    {
        public int IntData { get; private set; }
        public float FloatData { get; private set; }
        public string StrData { get; private set; }
        public char CharData { get; private set; }
        public bool BoolData { get; private set; }

        public void Init()
        {
            IntData = 2;
            FloatData = 1.1f;
            StrData = "AA";
            CharData = 'A';
            BoolData = true;
        }

        public override string ToString() =>
            IntData + " :: " + FloatData + " :: " + StrData + " :: " + CharData + " :: " + BoolData;
    }
}
