using System;

namespace Copy
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "张含韵",
                Age = 18,
                Data = new byte[3] { 9, 9, 9 },
            };
            Person dcP = (Person)person.Clone();
            Person scP = person.ShallowCopy();

            person.Name = "杨超越";
            person.Age = 28;
            person.Data[0] = 99;

            Console.WriteLine(person.ToString());
            Console.WriteLine("DeepCopy:" + dcP.ToString());
            Console.WriteLine("ShallowCopy:" + scP.ToString());
        }
    }


    public class Person : ICloneable
    {
        public string Name { get; set; }
        public uint Age { get; set; }

        public byte[] Data { get; set; }

        //DeepCopy
        public object Clone()
        {
            byte[] data = new byte[3];

            this.Data.CopyTo(data, 0);//这里只需要拷贝源对象的数据，不需要拷贝引用
            Person person = new Person
            {
                Name = this.Name,
                Age = this.Age,
                Data = data,//所以不能在这里直接赋值
            };
            return person;
        }

        //ShallowCopy
        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Name} {Age} {BitConverter.ToString(Data)}";
        }
    }
}
