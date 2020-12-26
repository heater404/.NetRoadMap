using System;
using System.Text.RegularExpressions;

namespace DotNetRodeMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var matches = Regex.Match("wfwf\u000713r321", @"\a");
            foreach (var group in matches.Groups)
            {
                Console.WriteLine(group.ToString());
            }
        }
    }
}
