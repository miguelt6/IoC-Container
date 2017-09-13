using Abstractions;
using DIP.HighLevelModule;
using DIP.Implementations;
using DIP.MyIoCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container();
            DIRegistration(container);
            Copy copy = new Copy(container);

            copy.DoCopy();
            Console.Read();
        }
        static void DIRegistration(Container container)
        {
            container.Register<IReader, KeyboardReader>();
            container.Register<IWriter, PrinterWriter>();
            container.Register<IPrinter, PrinterPrint>();
        }
    }
}
