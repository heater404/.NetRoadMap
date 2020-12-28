using System;
using System.Text.RegularExpressions;

namespace DotNetRodeMap
{
    class Program
    {
        static void Main(string[] args)
        {
            /*合法的新浪邮箱规则：
             * 有且仅有一个@和.
             * @在.之前  且@不能是第一位 .不能是最后一位
             * @与.不能相邻
             * 新浪邮箱应该以@sina.com结尾
             */

            //while (true)
            //{
            //    Console.WriteLine("input a email address please!");
            //    string? input = Console.ReadLine();

            //    Console.WriteLine(Regex.IsMatch(input, @"^[^.@]+(@sina.com)$"));
            //}

            /*
             * 将Age=18 Name="21e1yh1" Age=20 Name="1rqr" Age=30 Name="r3q23r"
             * 中所有的Name替换为张含韵
             */
            string input = @"Age=18 Name=""21e1yh1"" Age=20 Name=""1rqr"" Age=30 Name=""r3q23r""";
            string pattern = @"(?<= (Name="")).+?(?="")";//使用分贪婪模式匹配里面的名字

            Console.WriteLine(Regex.Replace(input, pattern, "张含韵"));
        }
    }
}
