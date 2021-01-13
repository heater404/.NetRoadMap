using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Foo> foos = new List<Foo>
            {
                new Foo{ Time=DateTime.Now, Member1=0x11,Member2="zhanghanyun1",Member3=true,Member4=new byte[]{ 0x22,0x33,0x44} },
                 new Foo{Time=DateTime.Now, Member1=0x11,Member2="zhanghanyun2",Member3=true,Member4=new byte[]{ 0x22,0x33,0x44} },
                  new Foo{ Time=DateTime.Now,Member1=0x11,Member2="zhanghanyun3",Member3=true,Member4=new byte[]{ 0x22,0x33,0x44} },
            };

            string path = @"test.csv";

            using (StreamWriter sw = new StreamWriter(path))
            {
                using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    cw.Configuration.RegisterClassMap<FooMap>();
                    cw.WriteRecords<Foo>(foos);
                }
            }

            using (StreamReader sr = new StreamReader(path))
            {
                using (CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    cr.Configuration.RegisterClassMap<FooMap>();
                    List<Foo> f = cr.GetRecords<Foo>().ToList();

                }
            }
        }
    }

    public class Foo
    {
        public DateTime Time { get; set; }

        public UInt16 Member1 { get; set; }

        public string Member2 { get; set; }

        public bool Member3 { get; set; }

        public byte[] Member4 { get; set; }
    }

    public class DecimalToHexConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
           return (UInt16)Convert.ToUInt16(text, 16);
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value is UInt16 t)
            {
                return "0x" + t.ToString("x4");
            }
            return "";
        }
    }

    public class FooMap : ClassMap<Foo>
    {
        public FooMap()
        {
            Map(m => m.Time).Name("Time");
            Map(m => m.Member1).Name("m1").TypeConverter<DecimalToHexConverter>();
            Map(m => m.Member2).Name("m2");
            Map(m => m.Member3).Name("m3");
            Map(m => m.Member4).Name("m4");
        }
    }
}
