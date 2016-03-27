using System;
using System.Text.RegularExpressions;

namespace SharpDXEngine.Utilities.Helpers
{
    static class StringHelper
    {
        public static String convertToPassword(String str)
        {
            return new Regex("\\S").Replace(str, "*");
        }
    }
}
