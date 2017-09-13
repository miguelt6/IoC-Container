using Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Implementations
{
    public class PrinterPrint : IPrinter
    {
        public void Print(string data)
        {
            Console.WriteLine(string.Format("Printing to \"Printer\": [{0}]", data));
        }
    }
}
