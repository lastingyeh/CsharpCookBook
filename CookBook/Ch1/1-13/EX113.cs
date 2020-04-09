using System;
using System.Collections.Generic;
using System.Text;

namespace CookBook.Ch1._1_13
{
    public static class EX113
    {
        public static void ShowSettingFieldsToDefaults()
        {
            DefaultValueExample<int> dv = new DefaultValueExample<int>();

            bool isDefault = dv.IsDefaultData();
            Console.WriteLine($"Initial data: {isDefault}");

            dv.SetData(100);

            isDefault = dv.IsDefaultData();
            Console.WriteLine($"Set data: {isDefault}");
        }
    }
}
