using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.SpecialsChar
{
    public static class RemoveSpecialChars
    {
        public static string Clear(string str)
        {
            string deger = str;


            deger = deger.Replace(",", "");
            deger = deger.Replace(".", "");
            deger = deger.Replace("/", "");
            deger = deger.Replace("!", "");
            deger = deger.Replace("@", "");
            deger = deger.Replace("#", "");
            deger = deger.Replace("$", "");
            deger = deger.Replace("%", "");
            deger = deger.Replace("^", "");
            deger = deger.Replace("&", "");
            deger = deger.Replace("*", "");
            deger = deger.Replace("'", "");
            deger = deger.Replace("\"", "");
            deger = deger.Replace(";", "");
            deger = deger.Replace("_", "");
            deger = deger.Replace("(", "");
            deger = deger.Replace(")", "");
            deger = deger.Replace(":", "");
            deger = deger.Replace("|", "");
            deger = deger.Replace("[", "");
            deger = deger.Replace("]", "");
            deger = deger.Replace("<", "");
            deger = deger.Replace(">", "");
            deger = deger.Replace("script", "");
            deger = deger.Replace("alert", "");
            deger = deger.Replace("select", "");
            deger = deger.Replace("from", "");



            return deger;
        }


        public static string FolderTitleClear(string str)
        {
            string deger = str;


            deger = deger.Replace(",", "");
            deger = deger.Replace(".", "");
            deger = deger.Replace("/", "");
            deger = deger.Replace("!", "");
            deger = deger.Replace("@", "");
            deger = deger.Replace("#", "");
            deger = deger.Replace("$", "");
            deger = deger.Replace("%", "");
            deger = deger.Replace("^", "");
            deger = deger.Replace("&", "");
            deger = deger.Replace("*", "");
            deger = deger.Replace("'", "");
            deger = deger.Replace("\"", "");
            deger = deger.Replace(";", "");
            deger = deger.Replace("_", "");
            deger = deger.Replace("(", "");
            deger = deger.Replace(")", "");
            deger = deger.Replace(":", "");
            deger = deger.Replace("|", "");
            deger = deger.Replace("[", "");
            deger = deger.Replace("]", "");
            deger = deger.Replace("<", "");
            deger = deger.Replace(">", "");
            deger = deger.Replace("script", "");
            deger = deger.Replace("alert", "");
            deger = deger.Replace("select", "");
            deger = deger.Replace("from", "");
            deger = deger.Replace("Ç", "c");
            deger = deger.Replace("ç", "c");
            deger = deger.Replace("Ğ", "g");
            deger = deger.Replace("ğ", "g");
            deger = deger.Replace("İ", "i");
            deger = deger.Replace("ı", "i");
            deger = deger.Replace("Ö", "o");
            deger = deger.Replace("ö", "o");
            deger = deger.Replace("Ş", "s");
            deger = deger.Replace("ş", "s");
            deger = deger.Replace("Ü", "u");
            deger = deger.Replace("ü", "u");




            return deger;
        }


        public static string FilesTitleClear(string str)
        {
            string deger = str;


            deger = deger.Replace(" ", "-");
            deger = deger.Replace(",", "");
            deger = deger.Replace(".", "");
            deger = deger.Replace("/", "");
            deger = deger.Replace("!", "");
            deger = deger.Replace("@", "");
            deger = deger.Replace("#", "");
            deger = deger.Replace("$", "");
            deger = deger.Replace("%", "");
            deger = deger.Replace("^", "");
            deger = deger.Replace("&", "");
            deger = deger.Replace("*", "");
            deger = deger.Replace("'", "");
            deger = deger.Replace("\"", "");
            deger = deger.Replace(";", "");
            deger = deger.Replace("(", "");
            deger = deger.Replace(")", "");
            deger = deger.Replace(":", "");
            deger = deger.Replace("|", "");
            deger = deger.Replace("[", "");
            deger = deger.Replace("]", "");
            deger = deger.Replace("<", "");
            deger = deger.Replace(">", "");
            deger = deger.Replace("script", "");
            deger = deger.Replace("alert", "");
            deger = deger.Replace("select", "");
            deger = deger.Replace("from", "");
            deger = deger.Replace("Ç", "c");
            deger = deger.Replace("ç", "c");
            deger = deger.Replace("Ğ", "g");
            deger = deger.Replace("ğ", "g");
            deger = deger.Replace("İ", "i");
            deger = deger.Replace("ı", "i");
            deger = deger.Replace("Ö", "o");
            deger = deger.Replace("ö", "o");
            deger = deger.Replace("Ş", "s");
            deger = deger.Replace("ş", "s");
            deger = deger.Replace("Ü", "u");
            deger = deger.Replace("ü", "u");



            return deger;
        }


        public static string FilesTitleSqlInectionRemove(string str)
        {
            string deger = str;


            deger = deger.Replace(",", "");
            deger = deger.Replace(".", "");
            deger = deger.Replace("/", "");
            deger = deger.Replace("!", "");
            deger = deger.Replace("@", "");
            deger = deger.Replace("#", "");
            deger = deger.Replace("$", "");
            deger = deger.Replace("%", "");
            deger = deger.Replace("^", "");
            deger = deger.Replace("&", "");
            deger = deger.Replace("*", "");
            deger = deger.Replace("'", "");
            deger = deger.Replace("\"", "");
            deger = deger.Replace(";", "");
            deger = deger.Replace("(", "");
            deger = deger.Replace(")", "");
            deger = deger.Replace(":", "");
            deger = deger.Replace("|", "");
            deger = deger.Replace("[", "");
            deger = deger.Replace("]", "");
            deger = deger.Replace("<", "");
            deger = deger.Replace(">", "");
            deger = deger.Replace("script", "");
            deger = deger.Replace("alert", "");
            deger = deger.Replace("select", "");
            deger = deger.Replace("from", "");

            return deger;
        }
    }
}
