using System;
using System.IO;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            //byte[] data = new byte[10] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99, 0xaa };

            //using (MemoryStream memory = new MemoryStream(data))
            //{
            //    using (BinaryReader binary = new BinaryReader(memory))
            //    {
            //        long len = binary.BaseStream.Length;

            //        while (binary.BaseStream.Position < len)
            //        {
            //            Console.Write(binary.ReadUInt16().ToString("X") + "\t");
            //        }
            //    }
            //}   
            NewMethod();
        }

        private static void NewMethod()
        {
            Person person = new Person();
            person.Dispose();
        }
    }


    public class Person:IDisposable
    {
        ~Person() => Dispose(false);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.
        }
    }
}
