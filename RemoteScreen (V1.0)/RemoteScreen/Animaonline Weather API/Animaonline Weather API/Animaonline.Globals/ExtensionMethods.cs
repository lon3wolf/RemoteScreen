using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Diagnostics;

namespace Animaonline.Globals
{
    [DebuggerNonUserCode]
    public static class ExtensionMethods
    {
        public static string AttributeWithErrorHandling(this XElement x, string name)
        {
            try
            {
                return x.Attribute(name).Value.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static decimal ToDecimal(this string input)
        {
            if (input.Contains('.'))
            {
                try
                {
                    return decimal.Parse(input.Replace('.', ','));
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                try
                {
                    return decimal.Parse(input);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static double ToDouble(this string input)
        {
            if (input.Contains('.'))
            {
                try
                {
                    return double.Parse(input.Replace('.', ','));
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                try
                {
                    return double.Parse(input);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static DateTime ToDateTime(this string input)
        {
            try
            {
                return DateTime.Parse(input);
            }
            catch
            {
                return new DateTime();
            }
        }
    }
}
