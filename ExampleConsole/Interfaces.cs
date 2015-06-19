using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * skipped - overriding interface definitions in derived classes, side effects of explicit interface 
 * implementation, selectively exposing interface methods, member hiding, interfaces on structs.
 * 
*/

namespace ExampleConsole
{
    [Chapter(8)]
    static class Interfaces
    {
        public static void Dispatch()
        {
            Document doc = new Document("hello");

            // as is better than is
            IStorable isDoc = doc as IStorable;
            if (isDoc != null)
                isDoc.Read();
            else
                Console.WriteLine("IStorable not supported");
            ILoggedCompressible ilcDoc = doc as ILoggedCompressible;
            if (ilcDoc != null)
                ilcDoc.Compress();
            else
                Console.WriteLine("ILoggedCompressible not supported");

            if (doc is IStorable)
            {
                isDoc = (IStorable)doc;
                isDoc.Write();
            }
            if (doc is ILoggedCompressible)
            {
                ilcDoc = (ILoggedCompressible)doc;
                ilcDoc.Compress();
            }
        }
    }

    [Chapter(8)]
    interface IStorable
    {
        void Read();
        void Write();
        int Status { get; set; }
    }

    [Chapter(8)]
    interface ICompressible
    {
        void Compress();
    }

    [Chapter(8)]
    interface ILoggedCompressible : ICompressible
    {
        void Log();
    }

    [Chapter(8)]
    class Document : IStorable, ICompressible
    {
        private int status = 0;

        public Document(string s)
        {
            Console.WriteLine("creating document with: {0}", s);
        }
                
        //public void Read()
        void IStorable.Read()
        {
            Console.WriteLine("read method");
        }

        void IStorable.Write()
        //public void Write()
        {
            Console.WriteLine("write method");
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public void Compress()
        {
            Console.WriteLine("compress method");
        }
    }
}
