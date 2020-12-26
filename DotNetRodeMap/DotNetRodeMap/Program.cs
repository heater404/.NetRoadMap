using System;
using System.Text.RegularExpressions;

namespace DotNetRodeMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var matches = Regex.Matches("adwq I ae awr rohs awd", @"\ba\S*");
            foreach (var match in matches)
            {
                Console.WriteLine(match.ToString());
            }
        }
    }
}
