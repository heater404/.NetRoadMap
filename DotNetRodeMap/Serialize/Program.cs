using ProtoBuf;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Serialize
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo
            {
                A = 0x11,
                B = 0x22,
                C = 0x33,
                D = true,
                E = "zhanghanyun",
                F = new UInt32[] { 0x44, 0x55, 0x66 },
            };
            Console.WriteLine(BitConverter.ToString(Encoding.UTF8.GetBytes(foo.E)));

            byte[] buffer = Struct2Bytes(foo);
            Console.WriteLine(BitConverter.ToString(buffer));

            Foo f = BytesToStuct2<Foo>(buffer);
        }

        //使用这个方法将你的结构体转化为bytes数组 
        public static byte[] Struct2Bytes(Foo f)
        {
            int size = Marshal.SizeOf(f);
            byte[] bytes = new byte[size];
            try
            {
                //分配结构体大小的内存空间
                IntPtr ptr = Marshal.AllocHGlobal(size);
                //将结构体转换为分配好的内存空间
                Marshal.StructureToPtr(f, ptr, false);
                //将内存空间拷贝到字节数组
                Marshal.Copy(ptr, bytes, 0, size);
                //释放内存空间
                Marshal.FreeHGlobal(ptr);
                return bytes;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                return bytes;
            }
        }

        //使用这个方法将byte数组转化为结构体 
        public static T BytesToStuct2<T>(byte[] data)
        {
            //得到结构体的大小 
            int size = Marshal.SizeOf(typeof(T));
            //byte数组长度小于结构体的大小 
            if (size > data.Length)
            {
                //返回空 
                return default;
            }
            //分配结构体大小的内存空间 
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间 
            Marshal.Copy(data, 0, structPtr, size);
            //将内存空间转换为目标结构体 
            object obj = Marshal.PtrToStructure(structPtr, typeof(T));
            //释放内存空间 
            Marshal.FreeHGlobal(structPtr);
            //返回结构体 
            return (T)obj;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public class Foo
        {
            private byte a;
            public byte A { get => a; set => a = value; }
            private UInt16 b;
            public UInt16 B { get => b; set => b = value; }
            private UInt32 c;
            public UInt32 C { get => c; set => c = value; }
            private bool d;
            public bool D { get => d; set => d = value; }

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            private string e;
            public string E { get => e; set => e = value; }

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            private UInt32[] f;
            public UInt32[] F { get => f; set => f = value; }
        }
    }
}
