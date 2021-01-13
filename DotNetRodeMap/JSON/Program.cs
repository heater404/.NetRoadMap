using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            //Foo foo = new Foo
            //{
            //    Member1 = 0x11,
            //    Member2 = 0x22,
            //    Member3 = 0x33,
            //    Member4 = true,
            //    Member5 = new UInt32[] { 0x44, 0x55, 0x66 },
            //    Member6=TestEnum.EnumB,
            //};
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReadCommentHandling=JsonCommentHandling.Skip,
                //Converters = { new JsonDecimalHexConverter()},
            };

            //string json = System.Text.Json.JsonSerializer.Serialize<Foo>(foo, options);

            //Console.WriteLine(json);
            //File.WriteAllText(@"test.json", json);

            string j = File.ReadAllText(@"test.json");
            Foo f = JsonSerializer.Deserialize<Foo>(j,options);
        }
    }

    public class UpperCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) =>
            name.ToUpper();
    }

    public enum TestEnum
    {
        EnumA=0,
        EnumB,
        EnumC
    }

    public class Foo
    {
        [JsonConverter(typeof(JsonDecimalHexConverter))]
        public byte Member1 { get; set; }

        [JsonPropertyName("M2")]
        public UInt16 Member2 { get; set; }

        [JsonIgnore]
        public UInt32 Member3 { get; set; }


        public bool Member4 { get; set; }

        public UInt32[] Member5 { get; set; }

        
        public TestEnum Member6 { get; set; }
    }

    public class JsonDecimalHexConverter : JsonConverter<byte>
    {
        public override byte Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
           string val= reader.GetString();

           return System.Convert.ToByte(val, 16);
        }

        public override void Write(Utf8JsonWriter writer, byte value, JsonSerializerOptions options)
        {
            writer.WriteStringValue("0x" + value.ToString("x"));
        }
    }
}
