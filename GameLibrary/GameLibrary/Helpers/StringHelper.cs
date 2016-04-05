using System;
using System.Text.RegularExpressions;

namespace GameLibrary.Helpers
{
    public static class StringHelper
    {
        public static String convertToPassword(String str)
        {
            return new Regex("\\S").Replace(str, "*");
        }
    }
}
